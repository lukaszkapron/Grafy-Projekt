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
       
        TextBox GenerujTxt(int i) //Generuje TextBox
        {
            TextBox tb = new TextBox();
            tb.Name = "Textbox" + i.ToString();
            tb.Width = 40;
            tb.Height = 40;
            return tb;
        }
        Label GenerujLabel(int i) // Generuje Label dla numerów wierszy i kolumn
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

        //Button generuj macierz
        private void button1_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            int matrixSize = (int)numericUpDown1.Value;
            int txtBoxAmount = matrixSize * matrixSize;     
            flowLayoutPanel1.Width = (matrixSize+1) * 40;
            label2.Text = "Podaj macierz incydencji";
            int n = 0;

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

        // Button Szukaj cyklu
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        // Button do Listy
        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            int liczbaWierzchołków = (int)numericUpDown1.Value;
            int liczbaKrawędzi = (int)numericUpDown2.Value;
            flowLayoutPanel1.Width = 200;
            label2.Text = "Podaj listę";

            for (int i = 0; i < liczbaKrawędzi; i++)
            {
                if (i==0)
                {
                    Label lPusty = GenerujLabel(i);
                    lPusty.Width = 20;
                    lPusty.Text = "";
                    Label lStart = GenerujLabel(i);
                    lStart.Text = "początek";
                    lStart.Width = 70;
                    Label lKoniec = GenerujLabel(i);
                    lKoniec.Text = "koniec";
                    lKoniec.Width = 70;
                    Label lPusty3 = GenerujLabel(i);
                    lPusty3.Width = 10;
                    lPusty3.Text = "";
                    flowLayoutPanel1.Controls.Add(lPusty);
                    flowLayoutPanel1.Controls.Add(lStart);
                    flowLayoutPanel1.Controls.Add(lPusty3);
                    flowLayoutPanel1.Controls.Add(lKoniec);
                   

                }
                Label l = GenerujLabel(i+1);
                TextBox tStart = GenerujTxt(i);
                TextBox tKoniec = GenerujTxt(i);
                Label lPusty2 = GenerujLabel(i);
                lPusty2.Text = "";
                Label lStrzalka = GenerujLabel(i);
                lStrzalka.Text = "-->";
                
                flowLayoutPanel1.Controls.Add(l);
                flowLayoutPanel1.Controls.Add(tStart);
                flowLayoutPanel1.Controls.Add(lStrzalka);
                flowLayoutPanel1.Controls.Add(tKoniec);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
