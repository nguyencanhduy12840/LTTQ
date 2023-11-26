using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private Font currentFont;
        public Form1()
        {
            InitializeComponent();
            LoadFontsIntoComboBox();
            currentFont = richTextBox1.Font;
        }
        private void LoadFontsIntoComboBox()
        {
            
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            foreach (FontFamily fontFamily in fontFamilies)
            {
                toolStripComboBox1.Items.Add(fontFamily.Name);
            }
        }
        private void địnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.Color = richTextBox1.ForeColor;
            fontDialog1.Font = fontDialog1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
                toolStripComboBox1.Text = fontDialog1.Font.Name;
                toolStripComboBox2.Text = Math.Round(Convert.ToDecimal(fontDialog1.Font.Size.ToString())).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Font Tahoma";
            toolStripComboBox2.Text = "14";
            richTextBox1.Font = new Font("Font Tahoma", 14);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripComboBox1.Text = "Font Tahoma";
            toolStripComboBox2.Text = "14";
            richTextBox1.Font = new Font("Font Tahoma", 14);
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ToggleUnderline();
        }
        private void ToggleFontStyle(FontStyle style)
        {
            Font currentFont = richTextBox1.SelectionFont;
            Font newFont;

            if (currentFont != null)
            {
                if (currentFont.Style.HasFlag(style))
                {
                    newFont = new Font(currentFont, currentFont.Style & ~style);
                }
                else
                {
                    newFont = new Font(currentFont, currentFont.Style | style);
                }
            }
            else
            {
                newFont = new Font(richTextBox1.Font, style);
            }

            richTextBox1.SelectionFont = newFont;
        }

        private void ToggleUnderline()
        {
            Font currentFont = richTextBox1.SelectionFont;
            Font newFont;

            if (currentFont != null)
            {
                
                if (currentFont.Style.HasFlag(FontStyle.Underline))
                {
                    newFont = new Font(currentFont, currentFont.Style & ~FontStyle.Underline);
                }
                else
                {
                    newFont = new Font(currentFont, currentFont.Style | FontStyle.Underline);
                }
            }
            else
            {
                
                newFont = new Font(richTextBox1.Font, FontStyle.Underline);
            }

            richTextBox1.SelectionFont = newFont;
        }
        private void UpdateFont()
        {
            string fontName = toolStripComboBox1.Text;
            int fontSize = Convert.ToInt32(toolStripComboBox2.Text);

            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newFontStyle = currentFont?.Style ?? FontStyle.Regular;

            if (currentFont?.Style.HasFlag(FontStyle.Bold) == true)
            {
                newFontStyle |= FontStyle.Bold;
            }
            if (currentFont?.Style.HasFlag(FontStyle.Italic) == true)
            {
                newFontStyle |= FontStyle.Italic;
            }
            if (currentFont?.Style.HasFlag(FontStyle.Underline) == true)
            {
                newFontStyle |= FontStyle.Underline;
            }

            Font newFont = new Font(fontName, fontSize, newFontStyle);
            richTextBox1.SelectionFont = newFont;
        }
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TextFile|*.txt;*.rtf";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = openFileDialog1.OpenFile();
                StreamReader reader = new StreamReader(myStream);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
                myStream.Close();
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
             saveFileDialog1.Filter = "Text File(*.rtf)|*.rtf";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK)
             {
                string filePath = saveFileDialog1.FileName;
                if (File.Exists(filePath))
                {
                    StreamWriter writer = new StreamWriter(filePath);
                    writer.Write(richTextBox1.Text);
                    writer.Close();
                    MessageBox.Show("Da luu thanh cong");                
                }
                else
                {
                    Stream myStream = saveFileDialog1.OpenFile();
                    StreamWriter writer = new StreamWriter(myStream);
                    writer.Write(richTextBox1.Text);
                    writer.Close();
                    myStream.Close();
                }
            }
        }
    }
}
