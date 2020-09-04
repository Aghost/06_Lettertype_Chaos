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
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "1234\n1234\n1234\n1234";
    }

        private void changeText()
        {
            richTextBox1.Font = new Font("Arial", 12);

            Point p = new Point(1,1);

            foreach (char ch in richTextBox1.Text.ToCharArray())
            {
                richTextBox2.Text += richTextBox1.GetCharFromPosition(p);

                if (ch == '\n')     // klopt nog niet helemaal
                {
                    p.X = 0;
                    p.Y += 1;
                }

                p.X += 1;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeText();
        }
    }
}
