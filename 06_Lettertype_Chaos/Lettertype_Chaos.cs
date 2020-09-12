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
            richTextBox1.Text = "0123456789abcdefghijklmnopqrstuvwxyz\n0123456789abcdefghijklmnopqrstuvwxyz\n";
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

            Console.WriteLine("Fonts loaded!");
        }

        private void LoadFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
            }

        }

        private void resetText()
        {
            Point p = new Point(0,0);
            Random rnd = new Random();
            char[] richText = richTextBox1.Text.ToCharArray();
            richTextBox1.Text = "";

            int counter = 0;
            foreach (char ch in richText)
            {
                int randomNr = rnd.Next(1, CollectionSize);
 
                if (ch == '\n') {
                    richTextBox1.Text += '\n';
                    p.X = 0;
                    p.Y += 1;
                } else {
                    richTextBox1.Text += ch;
                    richTextBox1.Select(counter, counter + 1);
                    richTextBox1.DeselectAll();
                }
                p.X += 1;
                counter++;
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (char c in richTextBox1.Text)
            {
                i++;
                richTextBox1.Select(i - 1, 1);

                Random rnd = new Random();
                int randomNr = rnd.Next(1, CollectionSize);
                richTextBox1.SelectionFont = new Font(fontCollection[randomNr], 14);

                richTextBox1.DeselectAll();
            }

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetText();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

    }
}
