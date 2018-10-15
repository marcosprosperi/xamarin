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
    class Jugador
    {
        private string nombre;
        private int maxScore;


        public Jugador(string nom, int intentos)
        {
            Nombre = nom;
            MaxScore = intentos;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int MaxScore { get => maxScore; set => maxScore = value; }
    }
}