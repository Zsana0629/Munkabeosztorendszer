using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves.feladat_CIPRIQ
{
    
    class MunkaCsoport
    {
 
        class Elem
        {
                public IMunkaraAlkalmas munkas;
                public Elem kovetkezo;
         }
            public int Length() 
            {
            int i = 0;
            Elem p = fej;
            while (p!= null)
            {
                p = p.kovetkezo;
                i++;
            }
            return i-1;
            }
            public IMunkaraAlkalmas this[int i] 
            { get 
            {
                if (i==0)
                {
                    return fej.munkas;
                }
                else
                {
                    Elem p = fej;
                    int index = 0;
                    while (p!=null && index <= i)
                    {
                        p = p.kovetkezo;
                        index++;
                    }
                    if (p==null)
                    {
                        throw new Exception("Nincs ilyen indexű elem");
                    }
                    else
                    {
                        return p.munkas;
                    }
                }
            }
            }
            Elem fej;
            
            public int Azon { get { return szamgeneralo(fej.munkas); } } //a fejben lévő munkás azonosítójában lévő szám
            int szamgeneralo(IMunkaraAlkalmas parameter) //kivágja a számokat tartalmazó részt az azonosítóból
            {
                string valami = parameter.DolgozoAzonosito.Substring(3, 3);
                return Convert.ToInt32(valami);
            }
            public void Beszuras(IMunkaraAlkalmas munkas)
            {
                Elem uj = new Elem();
                uj.munkas = munkas;
                if (fej==null)
                {
                    uj.kovetkezo = null;
                    fej = uj;
                }
                else
                {
                    if (szamgeneralo(fej.munkas)>szamgeneralo(uj.munkas))
                    {
                        uj.kovetkezo = fej;
                        fej = uj;
                    }
                    else
                    {
                        Elem p = fej;
                        Elem e = null;
                        while (p != null && szamgeneralo(p.munkas) < szamgeneralo(uj.munkas))
                        {
                            e = p;
                            p = p.kovetkezo;
                        }
                        if (p==null)
                        {
                           uj.kovetkezo = null;
                            e.kovetkezo = uj;
                        }
                        else
                        {
                            uj.kovetkezo = p;
                            e.kovetkezo = uj;
                        }
                    
                }
            }
        }
    }
}
