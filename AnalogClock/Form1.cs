﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AnalogClock
{
    enum STATUS { STOP, START, RESET };

    public partial class Form1 : Form
    {

        private STATUS status = STATUS.RESET;
        int stopWatchSec = 0;
        int stopWatchMin = 0;

        Timer mTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            mTimer.Interval = 1000;
            mTimer.Tick += new EventHandler(onTimer);
            mTimer.Start();
            Text = "Analog clock";
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush black = new SolidBrush(Color.Black);
            InitializeTransform(g);
            //draw border
            for (int i = 0; i < 120; i++)
            {
                g.RotateTransform(5.0f);
                g.FillRectangle(black, 90, -5, 10, 10);
            }
            //draw hour mark
            for (int i = 0; i < 12; i++)
            {
                g.RotateTransform(30.0f);
                g.FillRectangle(white, 85, -5, 10, 10);
            }
            //draw minute mark
            for (int i = 0; i < 60; i++)
            {
                g.RotateTransform(6.0f);
                g.FillRectangle(black, 85, -10, 5, 1);
            }
            // рисуем циферблат секундомера
            InitializeTransformStopWatch(g);
            //draw border
            for (int i = 0; i < 120; i++)
            {
                g.RotateTransform(5.0f);
                g.FillRectangle(black, 90, -5, 10, 10);
            }
            //draw minute mark
            for (int i = 0; i < 60; i++)
            {
                g.RotateTransform(6.0f);
                g.FillRectangle(black, 85, -10, 5, 1);
            }
            // отрисовываем стрелки секундомера
            // минутная
            InitializeTransformStopWatch(g);
            g.RotateTransform(stopWatchMin * 6);
            DrawHand(g, red, 100, false);
            // секундная
            InitializeTransformStopWatch(g);
            g.RotateTransform(stopWatchSec * 6);
            DrawHand(g, green, 100, true);

            //get current time
            DateTime nowDateTime = DateTime.Now;
            int secondInt = nowDateTime.Second;
            int minuteInt = nowDateTime.Minute;
            int hourInt24 = nowDateTime.Hour;
            int hourInt = hourInt24 % 12;

            //digitalLabel.Text = String.Format("{0,2}:{1,2}:{2,2}", hourInt24, minuteInt, secondInt);
            String digitalClockString =
                String.Format("{0,2:00}:{1,2:00}:{2,2:00}", hourInt24, minuteInt, secondInt);

            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            g.ResetTransform();
            float scale = System.Math.Min(ClientSize.Width, ClientSize.Height) / 200.0f;
            g.ScaleTransform(scale, scale);
            g.DrawString(digitalClockString, drawFont, drawBrush, 0, toolStrip1.Height);
            
            InitializeTransform(g);
            //hour hand draw
            g.RotateTransform((hourInt * 30) + (minuteInt / 2));
            DrawHand(g, blue, 70, false);
            InitializeTransform(g);
            //minute hand draw
            g.RotateTransform(minuteInt * 6);
            DrawHand(g, red, 100, false);
            InitializeTransform(g);
            //second hand draw
            g.RotateTransform(secondInt * 6);
            DrawHand(g, green, 100, true);
            red.Dispose();
            green.Dispose();
            blue.Dispose();
            white.Dispose();
            black.Dispose();
        }

        private void DrawHand(Graphics g, SolidBrush solidBrush, int length, bool seen)
        {
            Point[] points = new Point[4];
            points[0].X = 0;
            points[0].Y = -length;
            points[1].X = (seen) ? -2 : -10;
            points[1].Y = 0;
            points[2].X = 0;
            points[2].Y = (seen) ? 2 : 10;
            points[3].X = (seen) ? 2 : 10;
            points[3].Y = 0;
            g.FillPolygon(solidBrush, points);
        }

        private void InitializeTransform(Graphics g)
        {
            g.ResetTransform();
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2 + toolStrip1.Height / 2);
            float scale = System.Math.Min(ClientSize.Width, ClientSize.Height - toolStrip1.Height) / 200.0f;
            g.ScaleTransform(scale, scale);
        }
        // преобразование для рисования секундомера
        private void InitializeTransformStopWatch(Graphics g)
        {
            g.ResetTransform();
            g.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2 + toolStrip1.Height / 2 + System.Math.Min(ClientSize.Width / 4, ClientSize.Height / 4));
            float scale = System.Math.Min(ClientSize.Width / 4, ClientSize.Height / 4 - toolStrip1.Height / 2) / 200.0f;
            g.ScaleTransform(scale, scale);
        }

        private void onTimer(object sender, EventArgs e)
        {
            if (status == STATUS.START)
            {
                if (stopWatchSec + 1 <= 59)
                {
                    stopWatchSec++;
                }
                else
                {
                    stopWatchSec = 0;
                    if (stopWatchMin + 1 <= 59)
                    {
                        stopWatchMin++;
                    }
                    else
                    {
                        stopWatchMin = 0;
                    }
                }
            }
            Invalidate();
        }

        private void toolStartButton_Click(object sender, EventArgs e)
        {
            status = STATUS.START;
        }

        private void toolStopButton_Click(object sender, EventArgs e)
        {
            status = STATUS.STOP;
        }

        private void toolResetButton_Click(object sender, EventArgs e)
        {
            status = STATUS.RESET;
            stopWatchSec = 0;
            stopWatchMin = 0;
        }
    }
}
