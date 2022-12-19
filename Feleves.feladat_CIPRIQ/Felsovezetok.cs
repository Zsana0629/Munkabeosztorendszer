using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    sealed class Felsovezetok : Alkalmazottak
    {
        public override int MunkaDij(int munkaora)
        {
            return munkaora * 5000;
        }
        public Felsovezetok(string nev, string azonosito):base(nev,azonosito)
        {

        }
        
    }
}
