using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaArboles_DiazSolizJhonCarlos
{
    public partial class Form1 : Form
    {
        ArbolBinario arbol = new ArbolBinario();

        //void MostrarRecorrido()
        //{
        //    listView1.Clear();
        //    for (int i = 0; i <= arbol.topeRecorrido - 1; i++)
        //        listView1.Items.Add(arbol.recorrido[i].ToString());
        //    arbol.topeRecorrido = 0;
        //}

        void MostrarRecorrido()
        {
            listView1.Clear();
            for (int i = 0; i <= arbol.topeRecorrido - 1; i++)
                listView1.Items.Add(arbol.recorrido[i].ToString());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arbol.crearLexicografico(Int32.Parse(textBox1.Text));
            txtBoxAlturaArbol.Text = arbol.alturaArbol(arbol.raiz, 1).ToString();
            textBox1.Clear();
            textBox1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            arbol.preOrdenRecursivo(arbol.raiz);
            MostrarRecorrido();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arbol.preOrdenNoRecursivo(arbol.raiz);
            MostrarRecorrido();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arbol.entreOrdenRecursivo(arbol.raiz);
            MostrarRecorrido();
        }

        private void btnPostOrdenNrecursivo_Click(object sender, EventArgs e)
        {
            arbol.postOrdenNoRecursivo(arbol.raiz);
            MostrarRecorrido();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            arbol.Eliminar(Int32.Parse(textBox2.Text));

            txtBoxAlturaArbol.Text = arbol.alturaArbol(arbol.raiz, 1).ToString();
            textBox2.Clear();

        }


        //boton para entre orden no recursivo
        private void button5_Click(object sender, EventArgs e)
        {
            arbol.entreOrdenNoRecursivo(arbol.raiz);
            MostrarRecorrido();
        }


        //boton para post orden recursivo
        private void button6_Click(object sender, EventArgs e)
        {
            arbol.postOrdenRecursivo(arbol.raiz);
        }


        //boton para mostrar en orden
        private void button7_Click(object sender, EventArgs e)
        {
            arbol.mostrarEnOrden(arbol.raiz);
        }
    }
}
