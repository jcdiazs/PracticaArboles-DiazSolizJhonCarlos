using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaArboles_DiazSolizJhonCarlos
{
    class ArbolBinario
    {

        public Nodo raiz;
        public int topeRecorrido = 0;
        public int[] recorrido = new int[50];
        public void crearLexicografico(int valorNodo)
        {
            Nodo p, q;
            Nodo aux = new Nodo();


            if (raiz == null)
            {
                raiz = new Nodo();
                raiz.Informacion = valorNodo;
                raiz.EnlaceIzquierdo = null;
                raiz.EnlaceDerecho = null;

            }
            else
            {
                p = raiz;
                while (p != null)
                {
                    if (valorNodo < p.Informacion)
                    {
                        aux = p;
                        p = p.EnlaceIzquierdo;

                    }
                    else
                    {
                        if (valorNodo > p.Informacion)
                        {
                            aux = p;
                            p = p.EnlaceDerecho;
                        }
                    }
                }


                if (valorNodo < aux.Informacion)
                {
                    q = new Nodo();
                    q.Informacion = valorNodo;
                    q.EnlaceIzquierdo = null;
                    q.EnlaceDerecho = null;
                    aux.EnlaceIzquierdo = q;


                }
                else
                {
                    if (valorNodo > aux.Informacion)
                    {
                        q = new Nodo();
                        q.Informacion = valorNodo;
                        q.EnlaceIzquierdo = null;
                        q.EnlaceDerecho = null;
                        aux.EnlaceDerecho = q;
                    }
                }
            }
        }





        public void preOrdenRecursivo(Nodo raiz)
        {
            if (raiz != null)
            {
                MessageBox.Show(raiz.Informacion.ToString());
                preOrdenRecursivo(raiz.EnlaceIzquierdo);
                preOrdenRecursivo(raiz.EnlaceDerecho);
            }
        }

        public void preOrdenNoRecursivo(Nodo raiz)
        {
            Nodo p;
            Nodo[] pila = new Nodo[50];
            int tope = 0;

            if (raiz != null)
            {
                p = raiz;
                while (p != null || tope > 0)
                {

                    while (p != null)
                    {
                        MessageBox.Show(p.Informacion.ToString());

                        tope++;
                        pila[tope] = p;
                        p = p.EnlaceIzquierdo;

                    }
                    p = pila[tope].EnlaceDerecho;
                    tope--;
                }

            }
        }





        public void entreOrdenRecursivo(Nodo raiz)
        {
            if (raiz != null)
            {
                entreOrdenRecursivo(raiz.EnlaceIzquierdo);
                MessageBox.Show(raiz.Informacion.ToString());

                entreOrdenRecursivo(raiz.EnlaceDerecho);
            }
        }

        //falta hacer entreorden no recursivo
        //listo para usar en el examen
        public void entreOrdenNoRecursivo(Nodo raiz)
        {
            Nodo p;
            Nodo[] pila = new Nodo[30];
            int tope = 0;

            if (raiz != null)
            {
                p = raiz;
                while (p != null || tope != 0)
                {
                    while (p != null)
                    {
                        tope++;
                        pila[tope] = p;
                        p = p.EnlaceIzquierdo;
                    }
                    MessageBox.Show(pila[tope].Informacion.ToString());
                    p = pila[tope].EnlaceDerecho;
                    tope--;
                }
            }
        }




        //
        public void postOrdenRecursivo(Nodo raiz)
        {
            if (raiz != null)
            {
                postOrdenRecursivo(raiz.EnlaceIzquierdo);
                postOrdenRecursivo(raiz.EnlaceDerecho);
                MessageBox.Show(raiz.Informacion.ToString());


            }
        }

        //post  orden no recursivo, siguiendo la diapositiva
        public void postOrdenNoRecursivo(Nodo raiz)
        {

           Nodo p;
            Nodo[] pila = new Nodo[20];
            int[] posicion = new int[20];
            int tope = 0;

            if (raiz != null)
            {
                p = raiz;
                while (p != null || tope != 0)
                {
                    while (p != null)
                    {
                        tope++;
                        pila[tope] = p;

                        posicion[tope] = 0;
                        p = p.EnlaceIzquierdo;

                    }
                    if (posicion[tope] == 0){
                        posicion[tope] = 1;
                        p = pila[tope].EnlaceDerecho;

                    }
                    else{ MessageBox.Show(pila[tope].Informacion.ToString());

                        tope--;
                    }

                }

            }
        }


        public Nodo recorrerNodoIzq(Nodo nodo)
        {
            if (nodo.EnlaceIzquierdo != null)
            {
                return recorrerNodoIzq(nodo.EnlaceIzquierdo);
            }
            return nodo;
        }

        public void Eliminar(int valorNodo)
        {
            Nodo p;
            Nodo padre = new Nodo();
            Nodo nodoIzquierdo = recorrerNodoIzq(raiz);
            MessageBox.Show(nodoIzquierdo.Informacion.ToString());

            p = raiz;
            while (p != null && p.Informacion != valorNodo)
            {
                if (valorNodo < p.Informacion)
                {
                    padre = p;
                    p = p.EnlaceIzquierdo;
                }
                else
                {
                    if (valorNodo > p.Informacion)
                    {
                        padre = p;
                        p = p.EnlaceDerecho;
                    }
                }
            }

            if (p == null)
            {
                MessageBox.Show("No se encontró el nodo que desea eliminar.");
            }
            else
            {
                //1
                if (p.EnlaceIzquierdo == null && p.EnlaceDerecho == null)
                {
                    if (p == raiz)
                    {
                        raiz = null;
                    }
                    if (p.Informacion > padre.Informacion)
                        padre.EnlaceDerecho = null;
                    else
                        padre.EnlaceIzquierdo = null;
                    return;
                }
                //2
                if (p.EnlaceIzquierdo != null && p.EnlaceDerecho == null)
                {
                    Nodo hijo = p.EnlaceIzquierdo;
                    if (p.Informacion > padre.Informacion)
                        padre.EnlaceDerecho = hijo;
                    else
                        padre.EnlaceIzquierdo = hijo;
                    return;
                }
                if (p.EnlaceIzquierdo == null && p.EnlaceDerecho != null)
                {
                    Nodo hijo = p.EnlaceDerecho;
                    if (p.Informacion > padre.Informacion)
                        padre.EnlaceDerecho = hijo;
                    else
                        padre.EnlaceIzquierdo = hijo;
                    return;
                }
                //3
                nodoIzquierdo = recorrerNodoIzq(p.EnlaceDerecho);
                MessageBox.Show(nodoIzquierdo.Informacion.ToString());
                if (nodoIzquierdo != null)
                {
                    int val = nodoIzquierdo.Informacion;
                    Eliminar(nodoIzquierdo.Informacion);
                    p.Informacion = val;
                    return;
                }
                MessageBox.Show("No se pudo eliminar.");
            }
        }



        //Altura
        public int alturaArbol(Nodo raiz, int altActual)
        {
            if (raiz == null) {
                return altActual - 1;
            }
            return Math.Max(alturaArbol(raiz.EnlaceIzquierdo, altActual + 1), alturaArbol(raiz.EnlaceDerecho, altActual + 1 ));
        }


        //Mostrar en orden, aun no entiendo que hace :( usa otra clase cola

        public void mostrarEnOrden(Nodo raiz)
        {
            Cola cola = new Cola();
            Nodo p = raiz;
            if (raiz != null)
            {
                cola.insertar(p);
                while (!cola.vacia())
                {
                    cola.eliminar();

                    //if (p != raiz)
                    //{
                    //    recorrido[topeRecorrido] = p.Info;
                    //    topeRecorrido++;
                    //}

                    if (p.EnlaceIzquierdo != null)
                        cola.insertar(p.EnlaceIzquierdo);
                    if (p.EnlaceDerecho != null)
                        cola.insertar(p.EnlaceDerecho);

                    p = cola.lista[cola.primero];
                }


            }

        }



    }
}
