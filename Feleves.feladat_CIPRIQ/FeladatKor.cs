using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    class FeladatKor
    {
        public string megnevezes { get; set; }
        public int Munkakod;
        public int IdoIgeny;
        public FeladatKor(string nev,int Ido)
        {
            megnevezes = nev;
            IdoIgeny = Ido;
            Munkakod = Munkakodgenerator();
        }
        int Munkakodgenerator()
        {
            int osszeg=0;
            for (int i = 0; i < megnevezes.Length; i++)
            {
                osszeg += (int)megnevezes[i];
            }
            Munkakod = osszeg;
            return Munkakod;
        }
        
    }
}
