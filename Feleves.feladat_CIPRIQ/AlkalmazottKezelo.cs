using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    class AlkalmazottKezelo
    {
        public IMunkaraAlkalmas generator(bool vezeto) 
        {
            Random r = new Random();
            string[] Vezeteknev = { "Kiss", "Nagy", "Közepes", "Kovács" };
            string[] Keresztnev = { "Béla", "Zsanett", "Rita", "Gábor" };
            string nev = Vezeteknev[r.Next(0, 4)] + " " + Keresztnev[r.Next(0, 4)];
            char nem;
            if (nev.Contains("Rita") || nev.Contains("Zsanett"))
            {
                nem = 'N';
            }
            else
            {
                nem = 'F';
            }
            string azonosito = AzonositoGeneralas(nem);
            if (vezeto)
            {
                Felsovezetok Felsovez = new Felsovezetok(nev, azonosito);
                return Felsovez;
            }
            else 
            {
                Kozalkalmazottak alkalmazott = new Kozalkalmazottak(nev, azonosito);
                return alkalmazott;
            }
        }
        public Munkacsoportfa munkacsoportfa(MunkaCsoport[] csoportok) //munkacsoportfa generálás
        {
            Munkacsoportfa fa = new Munkacsoportfa();
            for (int i = 0; i < csoportok.Length; i++)
            {
                fa.Beszuras(csoportok[i]);
            }
            return fa;
        }
        public MunkaCsoport CsoportLetrehozas(int darabszam,bool vezeto) // munkacsoport létrehozás 
        {
            
            MunkaCsoport csoport = new MunkaCsoport();
            for (int i = 0; i < darabszam; i++)
            {
                csoport.Beszuras(generator(vezeto));
            }
            return csoport;
        }
        string AzonositoGeneralas(char nem)         
        {
            Random r = new Random();
            string azonosito = "";
            if (nem != 'F' && nem != 'N')
            {
                throw new Exception("Hibás nem");
            }
            azonosito += nem+"-";
            azonosito += r.Next(100,1000);
            azonosito += (char)r.Next('A','Z')+(char)r.Next('A', 'Z');
            return azonosito;
        }
    }
}
