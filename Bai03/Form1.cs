using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co gay khong?", "Xac nhan", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hom nay la ngay " + DateTime.Now.ToString("dd/MM/yyyy") + " - Bay gio la " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Media File|*.avi;*.mpeg;*.wav;*.midi;*.mp4;*.mp3";
            openFileDialog1.Title = "Select a Media File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            }
        }
    }
}
