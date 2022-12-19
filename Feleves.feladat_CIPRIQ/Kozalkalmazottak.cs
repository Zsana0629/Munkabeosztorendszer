using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    sealed class Kozalkalmazottak : Alkalmazottak
    {
        public override int MunkaDij(int munkaora)
        {
            return munkaora * 2000;
        }
        public Kozalkalmazottak(string nev, string azonosito):base(nev,azonosito)
        {

        }
    }
}
