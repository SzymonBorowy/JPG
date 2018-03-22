using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PorownajZIPy;

namespace JPG
{
    public partial class PorownanieForm : Form
    {
        public PorownanieForm()
        {
            InitializeComponent();
        }

        #region ZIPy
        private void buttonWybierzZIPa1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Zip Files|*.zip;*.rar";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSciezkaZIP1.Text = openFileDialog1.FileName;
            }
        }

        private void buttonWybierzZIPa2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Zip Files|*.zip;*.rar";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSciezkaZIP2.Text = openFileDialog1.FileName;
            }
        }

        private void buttonWybierzZIPa3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSciezkaZIP3.Text = openFileDialog1.SelectedPath;
            }
        }

        private void buttonPorownajZIPy_Click(object sender, EventArgs e)
        {
            PorownajZip porownaj = new PorownajZip(textBoxSciezkaZIP1.Text, textBoxSciezkaZIP2.Text, textBoxSciezkaZIP3.Text);
            porownaj.pokazRoznice(checkBoxPokazDokladneRoznice.Checked);
            porownaj.start();
        }

        #endregion
    }
}
