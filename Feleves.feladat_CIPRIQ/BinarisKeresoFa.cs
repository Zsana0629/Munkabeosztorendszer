using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    class BinarisKeresoFa
    {
        class Elem
        {
            public Elem Bal;
            public Elem Jobb;
            public FeladatKor tartalom;

            public Elem(Elem bal, Elem jobb, FeladatKor tartalom)
            {
                Bal = bal;
                Jobb = jobb;
                this.tartalom = tartalom;
            }
            public Elem(FeladatKor tartalom) : this(null, null, tartalom)
            {

            }

        }
        Elem gyoker;
        void RendezettBeszuras(FeladatKor tartalom, ref Elem p)
        {
            if (p == null)
            {
                p.tartalom = tartalom;
                p.Bal = null;
                p.Jobb = null;
            }
            else
            {
                if (p.tartalom.Munkakod > tartalom.Munkakod)
                {
                    RendezettBeszuras(tartalom, ref p.Bal);
                }
                else
                {
                    if (p.tartalom.Munkakod < tartalom.Munkakod)
                    {
                        RendezettBeszuras(tartalom, ref p.Jobb);
                    }
                    else
                    {
                        throw new Exception("van már ilyen munkakód");
                    }
                }
            }
        }
        
    }
}
