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
    [Activity(Label = "ScoreActity")]
    public class ScoreActivity : Activity
    {
        ListView listaScore;
        List<Jugador> jugadores;
        Button btnMainMenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_score);
            listaScore = FindViewById<ListView>(Resource.Id.listView1);
            btnMainMenu = FindViewById<Button>(Resource.Id.button1);
            jugadores = new List<Jugador>();
            if(Intent.HasExtra("Jugadores")) 
                jugadores = JsonConvert.DeserializeObject<List<Jugador>>(Intent.GetStringExtra("Jugadores"));
            jugadores.Add(new Jugador("Matias", 6));
            jugadores.Add(new Jugador("Lucas", 3));
            jugadores.Add(new Jugador("Martin", 7));
            jugadores.Add(new Jugador("Marcos", 10));
            jugadores.Add(new Jugador("Gonzalo", 1));
            jugadores.Add(new Jugador("Laura", 2));
            jugadores.Add(new Jugador("Gabriela", 0));
            jugadores.Add(new Jugador("Monica", 3));
            var jug = jugadores.OrderBy(i => i.MaxScore);
            List<String> listaJugadoresScore = new List<string>();
            foreach (var jugador in jug)
            {
                listaJugadoresScore.Add(jugador.Nombre + " " + jugador.MaxScore);
            }

            ArrayAdapter arrayAdapter = null;
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listaJugadoresScore);
            listaScore.Adapter = arrayAdapter;
            arrayAdapter.NotifyDataSetChanged();

            btnMainMenu.Click += btnClickMainMenu;
        }



        public void btnClickMainMenu(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}