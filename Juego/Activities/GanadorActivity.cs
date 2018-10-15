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
using Juego.Classes;
using Newtonsoft.Json;

namespace Juego.Activities
{
    [Activity(Label = "GanadorActivity")]
    public class GanadorActivity : Activity
    {
        Button aceptar;
        EditText nombre;
        TextView intentos;
        int intentosGanador;
        List<Jugador> jugadores;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_ganador);
            jugadores = new List<Jugador>();
            aceptar = FindViewById<Button>(Resource.Id.button1);
            nombre = FindViewById<EditText>(Resource.Id.editText1);
            intentosGanador = Intent.GetIntExtra("Intentos",0);
            intentos = FindViewById<TextView>(Resource.Id.textView5);
            intentos.Text = "Intentos: " + intentosGanador;
            aceptar.Click += btnClickScore;

            nombre.TextChanged += (sender, args) =>
            {

                if (nombre.Text.Length != 0)
                {
                    aceptar.Enabled = true;
                }
                else
                {
                    aceptar.Enabled = false;
                }
            };


            // Create your application here
        }

        public void btnClickScore(object sender, EventArgs eventArgs) {
            var jugador = new Jugador(nombre.Text, intentosGanador);
            jugadores.Add(jugador);

            var intent = new Intent(this, typeof(ScoreActivity));
            intent.PutExtra("Jugadores", JsonConvert.SerializeObject(jugadores));
            
            StartActivity(intent);
            Finish();
        }
    }
}