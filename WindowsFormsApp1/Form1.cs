using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.PageUnit = GraphicsUnit.Millimeter;
            if (comboBox1.Text == "EAN 13")
            {
                g.PageScale = scale;
                //g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), 1, 1, 501, 1010);
                EAN13 ean = new EAN13(textBox1.Text);
                int cnt = ean.output.Length;
                panel1.Width = cnt;
                float x = g.DpiX;
                int s1 = Convert.ToInt32(cnt * scale) + 1;
                int s2 = Convert.ToInt32(s1 / 25.4);
                int res = (int)x * s2;

                panel1.Width = res;
                Draw(ref g, ean.output);
            }
            if (comboBox1.Text == "Code 128")
            {
                g.PageScale = scale;
                Code128B code = new Code128B(textBox1.Text);
                int cnt = code.output.Length;
                float x = g.DpiX;
                int s1 = Convert.ToInt32(cnt * scale) + 1;
                int s2 = Convert.ToInt32(s1 / 25.4);
                int res = (int)x * s2;

                panel1.Width = res;

               
            }

        }
    }
    }

