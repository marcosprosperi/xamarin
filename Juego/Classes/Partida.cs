using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Juego.Classes
{
    class Partida
    {

        private GeneradorNumero numero;
        private int intentos;

        public Partida()
        {
            Numero = new GeneradorNumero();
            Intentos = 0;
        }

        public int Intentos { get => intentos; set => intentos = value; }
        public GeneradorNumero Numero { get => numero; set => numero = value; }
    }
}



