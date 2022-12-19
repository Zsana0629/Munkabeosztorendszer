using System;

namespace Feleves.feladat_CIPRIQ
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                FeladatKor[] Vfeladatok = { new FeladatKor("Email olvasás", 35), new FeladatKor("Probléma kezelés", 10), new FeladatKor("Hivatalos ügyek", 66), new FeladatKor(" Megbeszélés", 40) };
            FeladatKor[] Kfeladatok = { new FeladatKor("Email olvasás", 15), new FeladatKor("Dolgozat javítás", 13), new FeladatKor("Jegybeírás", 60), new FeladatKor(" Értekezlet", 40) };
            AlkalmazottKezelo kezelo = new AlkalmazottKezelo();
            
                MunkaCsoport[] vezetok = { kezelo.CsoportLetrehozas(5, true), kezelo.CsoportLetrehozas(6, true), kezelo.CsoportLetrehozas(7, true) };
                MunkaCsoport[] kozalk = { kezelo.CsoportLetrehozas(5, false), kezelo.CsoportLetrehozas(6, false), kezelo.CsoportLetrehozas(7, false) };
            
                Munkacsoportfa Vezetofa = kezelo.munkacsoportfa(vezetok);
                Munkacsoportfa alkalmazott = kezelo.munkacsoportfa(kozalk);
                for (int i = 0; i < Vfeladatok.Length; i++)
                {
                    Vezetofa.BTSstart(Vfeladatok[i]);
                }
                for (int i = 0; i < Kfeladatok.Length; i++)
                {
                    alkalmazott.BTSstart(Kfeladatok[i]);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Ugyanazt a kulcsot generálta meg");
            }
            
            
            Console.ReadKey();
        }
    }
}
