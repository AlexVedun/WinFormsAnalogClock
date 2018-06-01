namespace AnalogClock
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.digitalLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStartButton = new System.Windows.Forms.ToolStripButton();
            this.toolResetButton = new System.Windows.Forms.ToolStripButton();
            this.toolStopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // digitalLabel
            // 
            this.digitalLabel.AutoSize = true;
            this.digitalLabel.Location = new System.Drawing.Point(0, 0);
            this.digitalLabel.Name = "digitalLabel";
            this.digitalLabel.Size = new System.Drawing.Size(0, 13);
            this.digitalLabel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStartButton,
            this.toolStopButton,
            this.toolResetButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(326, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStartButton
            // 
            this.toolStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStartButton.Image")));
            this.toolStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStartButton.Name = "toolStartButton";
            this.toolStartButton.Size = new System.Drawing.Size(35, 22);
            this.toolStartButton.Text = "Start";
            this.toolStartButton.Click += new System.EventHandler(this.toolStartButton_Click);
            // 
            // toolResetButton
            // 
            this.toolResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolResetButton.Image = ((System.Drawing.Image)(resources.GetObject("toolResetButton.Image")));
            this.toolResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolResetButton.Name = "toolResetButton";
            this.toolResetButton.Size = new System.Drawing.Size(39, 22);
            this.toolResetButton.Text = "Reset";
            this.toolResetButton.Click += new System.EventHandler(this.toolResetButton_Click);
            // 
            // toolStopButton
            // 
            this.toolStopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStopButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStopButton.Image")));
            this.toolStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStopButton.Name = "toolStopButton";
            this.toolStopButton.Size = new System.Drawing.Size(35, 22);
            this.toolStopButton.Text = "Stop";
            this.toolStopButton.Click += new System.EventHandler(this.toolStopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 282);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.digitalLabel);
            this.MinimumSize = new System.Drawing.Size(0, 100);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label digitalLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStartButton;
        private System.Windows.Forms.ToolStripButton toolResetButton;
        private System.Windows.Forms.ToolStripButton toolStopButton;
    }
}

