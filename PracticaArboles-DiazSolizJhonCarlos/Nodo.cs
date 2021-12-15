using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaArboles_DiazSolizJhonCarlos
{
    class Nodo
    {

        private int informacion;

        public int Informacion
        {
            get { return informacion; }
            set { informacion = value; }
        }



        private Nodo enlaceIzquierdo;

        public Nodo EnlaceIzquierdo
        {
            get { return enlaceIzquierdo; }
            set { enlaceIzquierdo = value; }
        }



        private Nodo enlaceDerecho;

        public Nodo EnlaceDerecho
        {
            get { return enlaceDerecho; }
            set { enlaceDerecho = value; }
        }


    }
}
