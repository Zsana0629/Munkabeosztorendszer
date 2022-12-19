using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    interface IMunkaraAlkalmas
    {
        double maximum { get; set; } // maximális ledolgozható óraszáma egy alkalmazottnak
        double ujterheles(int munkaora); // kiszámolja, hogy x órával leterhelve mennyi lenne a terhelése
        string Nev { get; set; }
        string DolgozoAzonosito { get; set; }
        int MunkaDij(int munkaora);
        void Terheles(int munkaóra);
        double Teherbiras();
        bool TerhelhetoMeg();
        
        BinarisKeresoFa Feladatkorok { get; set; }
    }
    
}
