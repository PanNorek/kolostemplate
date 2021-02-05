using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolostemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new PlytaAudio("Mata", "100 dni", "5.5.2020", 20.20, "rock");
            var p2 = new PlytaAudio("Tata", "1001 dni", "2.2.2020", 21.20, "rock");
            var p3 = new PlytaAudio("Rafał Nojek", "01 dni", "2.2.2002", 22.20, "rock");
            var p4 = new PlytaAudio("Mama", "010 dni", "12.2.2002", 32.20, "folk");
            
            var pt1 = new Plytoteka("regał", "999999999");
            pt1.DodajPlyte(p1);
            pt1.DodajPlyte(p2);
            pt1.DodajPlyte(p3);
            pt1.DodajPlyte(p4);
            Console.WriteLine(pt1);
            pt1.Zapisz("binarny.bin");
            var pt2 = Plytoteka.Odczytaj("binarny.bin");
            Console.WriteLine("/////////////");
            pt2.UsunPlyte("RN3");
            Console.WriteLine(pt2);
            Console.WriteLine(pt2.Szukaj(KategoriaMuzyki.rock).Count);
            Console.ReadLine();
        }
    }
}
