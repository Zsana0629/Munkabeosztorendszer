using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    class Munkacsoportfa
    {
        int Osszeg(int[] tomb) 
        {
            int osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                osszeg += tomb[i];
            }
            return osszeg;
        }
        private void BTS(MunkaCsoport r, int szint, int[] e, ref bool van, int szetosztando)
        {
            int i = 0;
            while (!van && i < r[szint].maximum)
            {
                i++;
                if (Fk(szint, r, i)) //van megoldás a szinten
                {
                    e[szint] = i; 
                    if (szint == r.Length() - 1)
                    {
                        if (szetosztando == Osszeg(e)) van = true;
                    }
                    else BTS(r, szint + 1, e, ref van, szetosztando);
                }
            }
        }

        private bool Fk(int szint, MunkaCsoport r, int ujertek) //A megoldás adott szintjén (ember) van e megoldás
        {
            if (r[szint].ujterheles(ujertek)> 15 && r[szint].ujterheles(ujertek) < 95)
                return true;
            else return false;
        }
        public void BTSstart(FeladatKor kor) { InOrderBTS(gyoker, kor); } //elindítja a BTS-t, meg tudja e oldani ez a csapat a feladatkört
        private void InOrderBTS(Elem p,FeladatKor kor) 
        {
            if (p!=null)
            {
                InOrderBTS(p.Bal,kor);
                bool van = false;
                int[] e = new int[p.csoport.Length()];
                BTS(p.csoport,0,e,ref van,kor.IdoIgeny);
                string kepes = van ? "Képes" : "Nem képes";
                Console.WriteLine($"A {p.csoport.Azon} azonosítójú csoport: {kepes} elvégezni a {kor.megnevezes}-t");
                InOrderBTS(p.Jobb,kor);
            }
        }
        class Elem
        {
            public Elem Jobb;
            public Elem Bal;
            public MunkaCsoport csoport;
            public Elem(Elem jobb, Elem bal, MunkaCsoport csoport)
            {

                Jobb = jobb;
                Bal = bal;
                this.csoport = csoport;
            }
            public Elem(MunkaCsoport csoport) : this(null, null, csoport)
            {

            }
        }
        Elem gyoker;
        public void Beszuras(MunkaCsoport tartalom) 
        {
            RendezettBeszuras(tartalom,ref gyoker);
        }
        void RendezettBeszuras(MunkaCsoport tartalom, ref Elem p)
        {
            if (p == null)
            {
                p = new Elem(tartalom);
                
            }
            else
            {
                if (p.csoport.Azon > tartalom.Azon)
                {
                    RendezettBeszuras(tartalom, ref p.Bal);
                }
                else
                {
                    if (p.csoport.Azon < tartalom.Azon)
                    {
                        RendezettBeszuras(tartalom, ref p.Jobb);
                    }
                    else
                    {
                        throw new Exception("van már ilyen munkakód!");
                    }
                }
            }
        }
    }
}
