using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace _06_Lettertype_Chaos
{
    
    public partial class Lettertype_Chaos : Form
    {
        static int CollectionSize = FontFamily.Families.Length;
        string[] fontCollection = new string[CollectionSize];

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "0123456789abcdefg\nhijklmnopqrstuvwxyz\n0123456789abcdefg\nhijklmnopqrstuvwxyz\n";
            LoadFonts();
        }

        public Lettertype_Chaos()
        {
            InitializeComponent();
        }

        private void LoadFonts()
        {
            int i = 0;
            foreach (FontFamily Current_Font in FontFamily.Families)
            {
                fontCollection[i] = Current_Font.Name;
                Console.WriteLine($"{Current_Font.Name} {i}");

                i++;
            }

            ResetTextFont();
        }

        private void ResetTextFont()
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = new Font(fontCollection[1], 12);
            richTextBox1.DeselectAll();
        }

        private void LoadFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int j = 0; j <= richTextBox1.Text.Length; j++)
            {
                int randomNr = rnd.Next(1, CollectionSize);

                richTextBox1.Select(j, 1);
                richTextBox1.SelectionFont = new Font(fontCollection[randomNr], 12);
                richTextBox1.DeselectAll();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextFont();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

    }
}
