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
	// Co trzeba zrobić:
	// 1. -zdecydować czy dajemy możliwość wpisawania macierzy sąsiedztwa czy tylko liste wierzchołków
	// 2. Zrobić tak, żeby po kliknięciu szukaj cyklu zostały dodane krawędzie funkcją addEdge
	// 3. Obsłużyć błędy czyli gdy nie wszystkie krawędzie wpisane itp.
	// 4. Obsłużyć przycisk szukaj cyklu żeby szukał cyklu XD
	// 5. Przemyśleć błędy użyrkownika
	// 6. Opisać algorytm i napisać instrukcje
	// 7. Jak coś to można poprawić GUI bo nie umiem w Design XD
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		// Niepotrzebne ale nie da się usunąć XD
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
		//Fajną macierz generuje chyba
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
            List <TextBox> listaTextBoxow = new List<TextBox>();
			// pętla for tworzy listę "listaTextBoxow", w której są wszystkie textboxy z macierzy lub listy krawędzi z GUI
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (flowLayoutPanel1.Controls[i] is TextBox)
                {
                    listaTextBoxow.Add((TextBox)flowLayoutPanel1.Controls[i]);
                }
            }


            //TextBox x = listaTextBoxow[5];
            //label8.Text = x.Text;
        }

        // Button do Listy
		// Tworzy listę krawędzi
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
		// To nie potrzebne ale nie da się usunąć XD
        private void label4_Click(object sender, EventArgs e)
        {
            
        }




		//Algortym do szukania cykli:

		// Klasa Węzeł listy sąsiedztwa
		public class AjlistNode
		{
			public int id;
			public AjlistNode next; //następny sąsiad
			public AjlistNode(int id)
			{
				this.id = id;
				this.next = null;
			}
		}
		// Klasa Wierzhołki
		public class Vertices
		{
			public int data;
			public AjlistNode next; //następny węzeł
			public AjlistNode last; //poprzedni węzeł
			public Vertices(int data)
			{
				this.data = data;
				this.next = null;
				this.last = null;
			}
		}
		// klasa Graf
		public class Graph
		{

			public int size; // Liczba wierczhołkow
			public Vertices[] node; // Tablica zawiera Wierzchołki które mówią o tym z jakimi innymi wierzchołkami jest on połączony
			public Graph(int size)
			{
				this.size = size;
				this.node = new Vertices[size];
				this.setData();
			}
			public void setData()
			{
				if (size <= 0)
				{
					Console.WriteLine("\nEmpty Graph"); // zmienić na MessageBox
				}
				else
				{
					for (int index = 0; index < size; index++)
					{				
						node[index] = new Vertices(index); // Początkowa wartość węzła
					}
				}
			}
			// Funkcja do łąćzenia wierchułków:
			public void connection(int start, int last)
			{				
				AjlistNode edge = new AjlistNode(last); 
				if (node[start].next == null)
				{
					node[start].next = edge;
				}
				else
				{
					// Dodanie edge na koniec
					node[start].last.next = edge;
				}
				// Pobranie ostatniego węzła
				node[start].last = edge;
			}
			//  Dodawanie nowej krawędzi:
			public void addEdge(int start, int last)
			{
				if (start >= 0 && start < size &&
					last >= 0 && last < size)
				{
					connection(start, last); 
				}
				else
				{
					Console.WriteLine("\nHere Something Wrong"); //Zmieniź na MessageBox
				}
			}
			public void printGraph()
			{
				if (size > 0)
				{
					// Drukowanie węzła list sąsiedztwa czyli np. 1--2,3,4     2--5,6 
					// Raczej nie jest nam potrzebna ta funkcja

					for (var index = 0; index < size; ++index)
					{
						Console.Write("\nAdjacency list of vertex " +
									  index + " :");
						var edge = node[index].next;
						while (edge != null)
						{
							// Display graph node 
							Console.Write("  " + node[edge.id].data);
							// Visit to next edge
							edge = edge.next;
						}
					}
				}
			}
			// Drukowanie cykli
			// Trzeba rozważyć czy chcemy drukować każdy cykl, czy tylko jeden
			// ta funkcja pobiera jeszcze wartość n która mowi o jakiej długości ma być cykl
			// potrzebujey żeby znaleźć najkrótszy cykl więc trzeba to przerobić
			public void printCycleByLength(bool[] visit, int start, int source, int length, int n, String result)
			{
				if (start >= size || source >= size || start < 0 || source < 0 || size <= 0)
				{
					return;
				}
				if (visit[start] == true)
				{
					// Here length are indicate number of edge
					if (start == source && length == n)
					{
						// Display cycle of length n
						Console.WriteLine("(" + result + ")");
					}
					return;
				}
				// Here modified the value of visited node
				visit[start] = true;
				// This is used to iterate nodes edges
				var edge = node[start].next;
				while (edge != null)
				{
					printCycleByLength(visit, edge.id, source, length + 1, n, result + "  " + edge.id);
					// Visit to next edge
					edge = edge.next;
				}
				// Reset the value of visited node status
				visit[start] = false;
			}
			// funckaj do wywoływania funkcji drukowania cykli, też trzeba zmienić "n"
			public void cycleByLength(int n)
			{
				if (n < 2 || n >= size)
				{
					return;
				}
				if (size <= 0)
				{
					// Empty graph
					return;
				}
				// Auxiliary space which is used to store 
				// information about visited node
				bool[] visit = new bool[this.size];
				Console.WriteLine("\nResult : ");
				for (var i = 0; i < this.size; ++i)
				{
					// Check cycle of node i to i with length n
					// visit - tablica odwiedzonych wiezchołków
					// i = numer wierzchołka
					// n == długość cyklu
					//
					printCycleByLength(visit, i, i, 0, n, "" + i.ToString());
				}
			}
		}
	}
}
