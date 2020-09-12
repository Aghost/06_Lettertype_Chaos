using System;
using System.Drawing;
using System.Linq;
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
                    
                    //richTextBox2.SelectionFont = new Font(fontCollection[randomNr], 20);

                    richTextBox2.DeselectAll();
                }

                p.X += 1;
                counter++;

                Console.WriteLine($"randomNr{randomNr} + ch{ch} counter{counter}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeText();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (char c in richTextBox2.Text)
            {
                i++;
                richTextBox2.Select(i - 1, 1);

                Random rnd = new Random();
                int randomNr = rnd.Next(1, CollectionSize);
                richTextBox2.SelectionFont = new Font(fontCollection[randomNr], 14);

                Console.WriteLine($"{richTextBox2.SelectedRtf}");
                richTextBox2.DeselectAll();
                //Console.WriteLine($"{i} <i c> {c}");
            }

            //Console.WriteLine(richTextBox2.SelectedText.Count());
        }
    }
}
