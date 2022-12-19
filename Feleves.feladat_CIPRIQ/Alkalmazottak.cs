using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    public delegate void NemDolgozik();
    abstract class Alkalmazottak : IMunkaraAlkalmas
    {
        public BinarisKeresoFa Feladatkorok { get; set; } 
        static Random r = new Random();
        event NemDolgozik NemAlkalmazhatoTobbet;
        public string Nev { get ; set ; }
        static double szam; //teherbírás
        public string DolgozoAzonosito { get ; set; }      
        double Terheltseg { get; set; }
        public double maximum { get; set; }
        
        protected Alkalmazottak(string nev, string azonosito)
        {
            Nev = nev;
            DolgozoAzonosito = azonosito;
            szam = r.NextDouble();
            maximum = 95 * Teherbiras();
        }

        abstract public int MunkaDij(int munkaora); 
        public  double Teherbiras()
        {
            
            return szam;
        }
      
        public void Terheles(int munkaora)
        {
            Terheltseg = munkaora * (int)Teherbiras();
            maximum -= (double)munkaora;
        }

        public bool TerhelhetoMeg()
        {
            if (Terheltseg < 95)
            {
              return true;
            }
            
            else
            {
              return false;
            }
            
        }

        public double ujterheles(int munkaora)
        {
            return (munkaora * szam)*100;
        }
    }
}
