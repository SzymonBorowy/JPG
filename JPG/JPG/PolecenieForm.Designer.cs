namespace JPG
{
    partial class PolecenieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWybierzPolecenie = new System.Windows.Forms.Button();
            this.textBoxPolecenie = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWybierzPolecenie
            // 
            this.buttonWybierzPolecenie.Location = new System.Drawing.Point(476, 12);
            this.buttonWybierzPolecenie.Name = "buttonWybierzPolecenie";
            this.buttonWybierzPolecenie.Size = new System.Drawing.Size(26, 20);
            this.buttonWybierzPolecenie.TabIndex = 42;
            this.buttonWybierzPolecenie.Text = "...";
            this.buttonWybierzPolecenie.UseVisualStyleBackColor = true;
            this.buttonWybierzPolecenie.Click += new System.EventHandler(this.buttonWybierzPolecenie_Click);
            // 
            // textBoxPolecenie
            // 
            this.textBoxPolecenie.Location = new System.Drawing.Point(12, 12);
            this.textBoxPolecenie.Name = "textBoxPolecenie";
            this.textBoxPolecenie.Size = new System.Drawing.Size(458, 20);
            this.textBoxPolecenie.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PolecenieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 86);
            this.Controls.Add(this.buttonWybierzPolecenie);
            this.Controls.Add(this.textBoxPolecenie);
            this.Controls.Add(this.button1);
            this.Name = "PolecenieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PolecenieForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWybierzPolecenie;
        private System.Windows.Forms.TextBox textBoxPolecenie;
        private System.Windows.Forms.Button button1;
    }
}