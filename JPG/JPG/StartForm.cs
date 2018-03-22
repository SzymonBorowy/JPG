using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JPG
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            Environment.ExitCode = 1;

        }

        //#region Interpretacja
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Interpretuj inter = new Interpretuj(textBoxPolecenie.Text);
        //}

        //private void buttonWybierzPolecenie_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        textBoxPolecenie.Text = openFileDialog1.FileName;
        //    }
        //}
        //#endregion



        //#region ZIPy
        //private void buttonWybierzZIPa1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    //openFileDialog1.Filter = "Zip Files|*.zip;*.rar";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        textBoxSciezkaZIP1.Text = openFileDialog1.FileName;
        //    }
        //}

        //private void buttonWybierzZIPa2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    //openFileDialog1.Filter = "Zip Files|*.zip;*.rar";
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        textBoxSciezkaZIP2.Text = openFileDialog1.FileName;
        //    }
        //}

        //private void buttonWybierzZIPa3_Click(object sender, EventArgs e)
        //{
        //    FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        textBoxSciezkaZIP3.Text = openFileDialog1.SelectedPath;
        //    }
        //}

        //private void buttonPorownajZIPy_Click(object sender, EventArgs e)
        //{
        //    PorownajZip porownaj = new PorownajZip(textBoxSciezkaZIP1.Text, textBoxSciezkaZIP2.Text, textBoxSciezkaZIP3.Text);
        //    porownaj.start();
        //}

        //#endregion

        private void buttonPolecenie_Click(object sender, EventArgs e)
        {
            PolecenieForm polecenie = new PolecenieForm();
            polecenie.Show();
        }

        private void buttonPorownaj_Click(object sender, EventArgs e)
        {
            PorownanieForm porownanie = new PorownanieForm();
            porownanie.Show();
        }
    }
}
