namespace JPG
{
    partial class PorownanieForm
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
            this.buttonPorownajZIPy = new System.Windows.Forms.Button();
            this.buttonWybierzZIPa3 = new System.Windows.Forms.Button();
            this.buttonWybierzZIPa2 = new System.Windows.Forms.Button();
            this.buttonWybierzZIPa1 = new System.Windows.Forms.Button();
            this.textBoxSciezkaZIP3 = new System.Windows.Forms.TextBox();
            this.textBoxSciezkaZIP2 = new System.Windows.Forms.TextBox();
            this.textBoxSciezkaZIP1 = new System.Windows.Forms.TextBox();
            this.checkBoxPokazDokladneRoznice = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonPorownajZIPy
            // 
            this.buttonPorownajZIPy.Location = new System.Drawing.Point(167, 94);
            this.buttonPorownajZIPy.Name = "buttonPorownajZIPy";
            this.buttonPorownajZIPy.Size = new System.Drawing.Size(75, 23);
            this.buttonPorownajZIPy.TabIndex = 45;
            this.buttonPorownajZIPy.Text = "Start";
            this.buttonPorownajZIPy.UseVisualStyleBackColor = true;
            this.buttonPorownajZIPy.Click += new System.EventHandler(this.buttonPorownajZIPy_Click);
            // 
            // buttonWybierzZIPa3
            // 
            this.buttonWybierzZIPa3.Location = new System.Drawing.Point(532, 63);
            this.buttonWybierzZIPa3.Name = "buttonWybierzZIPa3";
            this.buttonWybierzZIPa3.Size = new System.Drawing.Size(26, 20);
            this.buttonWybierzZIPa3.TabIndex = 44;
            this.buttonWybierzZIPa3.Text = "...";
            this.buttonWybierzZIPa3.UseVisualStyleBackColor = true;
            this.buttonWybierzZIPa3.Click += new System.EventHandler(this.buttonWybierzZIPa3_Click);
            // 
            // buttonWybierzZIPa2
            // 
            this.buttonWybierzZIPa2.Location = new System.Drawing.Point(532, 37);
            this.buttonWybierzZIPa2.Name = "buttonWybierzZIPa2";
            this.buttonWybierzZIPa2.Size = new System.Drawing.Size(26, 20);
            this.buttonWybierzZIPa2.TabIndex = 43;
            this.buttonWybierzZIPa2.Text = "...";
            this.buttonWybierzZIPa2.UseVisualStyleBackColor = true;
            this.buttonWybierzZIPa2.Click += new System.EventHandler(this.buttonWybierzZIPa2_Click);
            // 
            // buttonWybierzZIPa1
            // 
            this.buttonWybierzZIPa1.Location = new System.Drawing.Point(532, 11);
            this.buttonWybierzZIPa1.Name = "buttonWybierzZIPa1";
            this.buttonWybierzZIPa1.Size = new System.Drawing.Size(26, 20);
            this.buttonWybierzZIPa1.TabIndex = 42;
            this.buttonWybierzZIPa1.Text = "...";
            this.buttonWybierzZIPa1.UseVisualStyleBackColor = true;
            this.buttonWybierzZIPa1.Click += new System.EventHandler(this.buttonWybierzZIPa1_Click);
            // 
            // textBoxSciezkaZIP3
            // 
            this.textBoxSciezkaZIP3.Location = new System.Drawing.Point(12, 64);
            this.textBoxSciezkaZIP3.Name = "textBoxSciezkaZIP3";
            this.textBoxSciezkaZIP3.Size = new System.Drawing.Size(514, 20);
            this.textBoxSciezkaZIP3.TabIndex = 41;
            this.textBoxSciezkaZIP3.Text = "C:\\Users\\VOLTPC3\\Desktop\\";
            // 
            // textBoxSciezkaZIP2
            // 
            this.textBoxSciezkaZIP2.Location = new System.Drawing.Point(12, 38);
            this.textBoxSciezkaZIP2.Name = "textBoxSciezkaZIP2";
            this.textBoxSciezkaZIP2.Size = new System.Drawing.Size(514, 20);
            this.textBoxSciezkaZIP2.TabIndex = 40;
            this.textBoxSciezkaZIP2.Text = "C:\\Users\\VOLTPC3\\Desktop\\Raporty\\raport2.zip";
            // 
            // textBoxSciezkaZIP1
            // 
            this.textBoxSciezkaZIP1.Location = new System.Drawing.Point(12, 12);
            this.textBoxSciezkaZIP1.Name = "textBoxSciezkaZIP1";
            this.textBoxSciezkaZIP1.Size = new System.Drawing.Size(514, 20);
            this.textBoxSciezkaZIP1.TabIndex = 39;
            this.textBoxSciezkaZIP1.Text = "C:\\Users\\VOLTPC3\\Desktop\\Raporty\\raport1.zip";
            // 
            // checkBoxPokazDokladneRoznice
            // 
            this.checkBoxPokazDokladneRoznice.AutoSize = true;
            this.checkBoxPokazDokladneRoznice.Location = new System.Drawing.Point(12, 98);
            this.checkBoxPokazDokladneRoznice.Name = "checkBoxPokazDokladneRoznice";
            this.checkBoxPokazDokladneRoznice.Size = new System.Drawing.Size(149, 17);
            this.checkBoxPokazDokladneRoznice.TabIndex = 47;
            this.checkBoxPokazDokladneRoznice.Text = "Pokaż Dokałdne Różnice";
            this.checkBoxPokazDokladneRoznice.UseVisualStyleBackColor = true;
            // 
            // PorownanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 127);
            this.Controls.Add(this.checkBoxPokazDokladneRoznice);
            this.Controls.Add(this.buttonPorownajZIPy);
            this.Controls.Add(this.buttonWybierzZIPa3);
            this.Controls.Add(this.buttonWybierzZIPa2);
            this.Controls.Add(this.buttonWybierzZIPa1);
            this.Controls.Add(this.textBoxSciezkaZIP3);
            this.Controls.Add(this.textBoxSciezkaZIP2);
            this.Controls.Add(this.textBoxSciezkaZIP1);
            this.Name = "PorownanieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PorownanieForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPorownajZIPy;
        private System.Windows.Forms.Button buttonWybierzZIPa3;
        private System.Windows.Forms.Button buttonWybierzZIPa2;
        private System.Windows.Forms.Button buttonWybierzZIPa1;
        private System.Windows.Forms.TextBox textBoxSciezkaZIP3;
        private System.Windows.Forms.TextBox textBoxSciezkaZIP2;
        private System.Windows.Forms.TextBox textBoxSciezkaZIP1;
        private System.Windows.Forms.CheckBox checkBoxPokazDokladneRoznice;
    }
}