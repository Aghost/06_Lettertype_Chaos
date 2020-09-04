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

namespace _06_Lettertype_Chaos
{
    
    public partial class Form1 : Form
    {
        static int CollectionSize = FontFamily.Families.Length;
        string[] fontCollection = new string[CollectionSize];

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "1234\n1234\n1234\n1234";
            LoadFonts();
        }

        public Form1()
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

        private void changeText()
        {
            Point p = new Point(0,0);
            Random rnd = new Random();

            int counter = 0;

            foreach (char ch in richTextBox1.Text.ToCharArray())
            {
                int randomNr = rnd.Next(1, CollectionSize);
                //richTextBox1.Font = new Font(fontCollection[randomNr], 14);

                if (ch == '\n') {
                    richTextBox2.Text += '\n';
                    p.X = 0;
                    p.Y += 1;
                } else {
                    richTextBox2.Text += ch;
                    richTextBox2.Select(counter, counter + 1);
                    // new Font(fontCollection[randomNr], 14);

                    richTextBox2.SelectionFont = new Font(fontCollection[randomNr], 14);
                }

                p.X += 1;
                counter++;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeText();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            richTextBox2.Select(0, 10);

            Random rnd = new Random();
            int randomNr = rnd.Next(1, CollectionSize);
            richTextBox2.SelectionFont = new Font(fontCollection[randomNr], 14);

            Console.WriteLine($"{richTextBox2.SelectedRtf}");
            Console.WriteLine(richTextBox2.SelectedText.Count());
        }
    }
}
