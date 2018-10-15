using System;
using System.Collections;
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

    public class GeneradorNumero
    {

        private int[] num;

        //  private List<Integer> list;

        public GeneradorNumero()
        {
            Random rnd = new Random();
            int check;
            this.num = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    check = rnd.Next(1,9);
                else
                    check = rnd.Next(0,9);
                while (i != 0 && this.comprobar(num, check))
                {
                    check = rnd.Next(0, 9);
                }
                num[i] = check;
            }
        }


        public int[] getNum()
        {
            Random rnd = new Random();
            int check;
            if (num != null)
                return num;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                    check = rnd.Next(1,9);
                else
                    check = rnd.Next(0,9);
                while (this.comprobar(num, check))
                {
                    check = rnd.Next(0, 9);
                }
                num[i] = check;
            }
            return num;
        }



        public Boolean comprobar(int[] numeros, int num)
        {
            int max = numeros.Length;
            for (int i = 0; i < max; i++)
            {
                if (numeros[i] == num)
                    return true;
            }
            return false;
        }

        public Boolean buscarIguales(int nuevoNum)
        {
            int[] numeros = this.stringToArray(nuevoNum);
            for (int i = 0; i < numeros.Length; i++)
            {
                for (int j = i + 1; j < numeros.Length; j++)
                {
                    if (numeros[i] == numeros[j])
                        return true;
                }
            }
            return false;
        }

        public IDictionary<string, int> compararNumeros(int nuevoNum)
        {

            int[] nuevoNumEnArray = this.stringToArray(nuevoNum);

            for (int i = 3; i >= 0; i--)
            {

                nuevoNumEnArray[i] = nuevoNum % 10;
                nuevoNum = nuevoNum / 10;
            }

            int bien = 0;
            int regular = 0;
            for (int i = 0; i < this.num.Length; i++)
            {
                if (nuevoNumEnArray[i] == this.num[i])
                    bien++;
                if (comprobar(this.num, nuevoNumEnArray[i]))
                    regular++;
            }

            IDictionary<string, int> intento = new Dictionary<string, int>();
            regular = regular - bien;
            intento.Add("Bien", bien);
            intento.Add("Regular", regular);
            return intento;
        }


        public String getNumString()
        {
            String numString = "";
            for (int i = 0; i < num.Length; i++)
                numString += num[i];
            return numString;
        }

        public int[] stringToArray(int nuevoNum)
        {
            int oldNuevoNum = nuevoNum;
            int[] nuevoNumEnArray = new int[4];

            for (int i = 3; i >= 0; i--)
            {

                nuevoNumEnArray[i] = nuevoNum % 10;
                nuevoNum = nuevoNum / 10;
            }
            return nuevoNumEnArray;
        }

    }

}