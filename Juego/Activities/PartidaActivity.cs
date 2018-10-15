using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;
using Juego.Activities;
using Juego.Classes;

namespace Juego
{
    [Activity(Label = "PartidaActivity", Theme = "@style/AppTheme")]
    public class PartidaActivity : Activity
    {
        Partida partida = new Partida();
        Button buttonGo;
        EditText textNum;
        TextView textError;
        Button buttonRendirme;
        int cantPruebas = 0;
        ListView listaPruebas;
        List<String> numerosPruebas;
        Button verNumero;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_partida);
            buttonGo = this.FindViewById<Button>(Resource.Id.button1);
            textNum = this.FindViewById<EditText>(Resource.Id.editText1);
            textError = this.FindViewById<TextView>(Resource.Id.textView2);
            buttonRendirme = this.FindViewById<Button>(Resource.Id.button2);
            listaPruebas = this.FindViewById<ListView>(Resource.Id.listView1);
            verNumero = this.FindViewById<Button>(Resource.Id.button3);
            textError.Text = "";
            numerosPruebas = new List<string>();
            buttonGo.Click += OnButtonClickedGo;
            textNum.SetFilters(new Android.Text.IInputFilter[] { new InputFilterLengthFilter(4) });
            textNum.TextChanged += (sender, args) =>
            {
                     
                if (textNum.Text.Length == 4)
                {
                    buttonGo.Enabled = true;
                } else
                {
                    buttonGo.Enabled = false;
                }
            };
            buttonRendirme.Click += btnRendirme;
            verNumero.Click += (sender, args) =>
            {
                textError.Text = partida.Numero.getNumString();
            };
            // Create your application here




        }

        public void OnButtonClickedGo(object sender, EventArgs eventArgs)
        {
            var numeroTipeado = int.Parse(textNum.Text);
            if ((numeroTipeado >= 1023) && (numeroTipeado <= 9876) && !buscarIguales())
            {
                
                cantPruebas++;
                IDictionary<string, int> comparacion = this.comprobar();
                var textListfield = textNum.Text + " " + comparacion["Bien"] + "B " + comparacion["Regular"] + "R " + "Intento Nro " + cantPruebas;
                numerosPruebas.Add(textListfield);
                if (comparacion["Bien"] == 4)
                {
                    var intent = new Intent(this, typeof(GanadorActivity));
                    intent.PutExtra("Intentos", cantPruebas);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    textError.Text = "";
                    ArrayAdapter arrayAdapter = null;
                    arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, numerosPruebas);
                    listaPruebas.Adapter = arrayAdapter;
                    arrayAdapter.NotifyDataSetChanged();
                }

            }
            else
            {
                if (buscarIguales())
                {
                    textError.Text = "No puede poner numeros iguales";
                }
                else
                {
                    textError.Text = "El numero debe ser mayor a 1023 y menor a 9876!";
                }

            }
            textNum.Text = "";


        }

        private void btnRendirme(object sender, System.EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Perdiste!");
            alert.SetMessage("El Numero es: " + partida.Numero.getNumString());
            alert.SetButton("Aceptar", (c, ev) => {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            });
            alert.Show();
        }

        public Boolean buscarIguales()
        {
            return partida.Numero.buscarIguales(int.Parse(textNum.Text));
        }

        public IDictionary<string, int> comprobar()
        {
            return partida.Numero.compararNumeros(int.Parse(textNum.Text));
        }

        
    }
}