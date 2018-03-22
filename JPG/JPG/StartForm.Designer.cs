namespace JPG
{
    partial class StartForm
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
            this.buttonPolecenie = new System.Windows.Forms.Button();
            this.buttonPorownaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPolecenie
            // 
            this.buttonPolecenie.Location = new System.Drawing.Point(12, 12);
            this.buttonPolecenie.Name = "buttonPolecenie";
            this.buttonPolecenie.Size = new System.Drawing.Size(99, 56);
            this.buttonPolecenie.TabIndex = 40;
            this.buttonPolecenie.Text = "Polecenie";
            this.buttonPolecenie.UseVisualStyleBackColor = true;
            this.buttonPolecenie.Click += new System.EventHandler(this.buttonPolecenie_Click);
            // 
            // buttonPorownaj
            // 
            this.buttonPorownaj.Location = new System.Drawing.Point(12, 74);
            this.buttonPorownaj.Name = "buttonPorownaj";
            this.buttonPorownaj.Size = new System.Drawing.Size(99, 56);
            this.buttonPorownaj.TabIndex = 41;
            this.buttonPorownaj.Text = "Porownaj";
            this.buttonPorownaj.UseVisualStyleBackColor = true;
            this.buttonPorownaj.Click += new System.EventHandler(this.buttonPorownaj_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(121, 145);
            this.Controls.Add(this.buttonPorownaj);
            this.Controls.Add(this.buttonPolecenie);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPolecenie;
        private System.Windows.Forms.Button buttonPorownaj;
    }
}

