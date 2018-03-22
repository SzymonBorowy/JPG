using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InterpretacjaTekstu;

namespace JPG
{
    public partial class PolecenieForm : Form
    {
        public PolecenieForm()
        {
            InitializeComponent();
        }

        #region Interpretacja
        private void button1_Click(object sender, EventArgs e)
        {
            Interpretuj inter = new Interpretuj(textBoxPolecenie.Text);
        }

        private void buttonWybierzPolecenie_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPolecenie.Text = openFileDialog1.FileName;
            }
        }
        #endregion
    }
}
