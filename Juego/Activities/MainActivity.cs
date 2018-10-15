using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using Juego.Classes;
using System.Collections.Generic;
using Juego.Activities;

namespace Juego
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button but;
        Button butScore;
        Button butClose;
        



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            but = this.FindViewById<Button>(Resource.Id.button1);
            butScore = this.FindViewById<Button>(Resource.Id.button2);
            butClose = this.FindViewById<Button>(Resource.Id.button3);
            but.Click += OnButtonClicked;
            butScore.Click += btnClickScore;
            butClose.Click += btnClickClose;


            // Set our view from the "main" layout resource
        }

        public void OnButtonClicked(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(PartidaActivity));
            StartActivity(intent);
            Finish();

        }

        public void btnClickScore(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(ScoreActivity));
            StartActivity(intent);
            Finish();
        }


        public void btnClickClose(object sender, EventArgs eventArgs)
        {
            Finish();
        }

    }
}