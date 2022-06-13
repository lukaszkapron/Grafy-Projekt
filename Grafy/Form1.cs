using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        TextBox GenerujTxt(int i)
        {
            TextBox tb = new TextBox();
            tb.Name = "Textbox" + i.ToString();
            tb.Width = 40;
            tb.Height = 40;
            return tb;
        }
        Label GenerujLabel(int i)
        {
            Label l = new Label();
            l.Name = "Label" + i.ToString();
            l.Width = 40;
            l.Height = 40;
            l.Text = i.ToString();
            l.Margin = new Padding(0);
            l.TextAlign = ContentAlignment.MiddleCenter;
            return l;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            int matrixSize = (int)numericUpDown1.Value;
            int txtBoxAmount = matrixSize * matrixSize;     
            flowLayoutPanel1.Width = (matrixSize+1) * 40;
            int n = 0;
            int numerwierwsza = 1;

            for (int i = 0; i <= matrixSize; i++)
            {
                Label l = GenerujLabel(i);
                flowLayoutPanel1.Controls.Add(l);
                
            }
            for (int i = 0; i < txtBoxAmount; i++)
            {
                if (i==0)
                {
                    Label l = GenerujLabel(n+1+matrixSize);            
                    flowLayoutPanel1.Controls.Add(l);
                    n++;
                    TextBox tb = GenerujTxt(i);
                    tb.Margin = new Padding(0, 0, 0, 0);
                    flowLayoutPanel1.Controls.Add(tb);
                    l.Text = n.ToString();
                }
                else if (i>0 && i==n*matrixSize)
                {
                    Label l = GenerujLabel(n + 1 + matrixSize);
                    flowLayoutPanel1.Controls.Add(l);
                    n++;
                    l.Text = n.ToString();
                    TextBox tb = GenerujTxt(i);
                    tb.Margin = new Padding(0, 0, 0, 0);
                    flowLayoutPanel1.Controls.Add(tb);
                }
                else
                {
                    TextBox tb = GenerujTxt(i);
                    tb.Margin = new Padding(0, 0, 0, 0);
                    flowLayoutPanel1.Controls.Add(tb);
                }
                
                
 

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
