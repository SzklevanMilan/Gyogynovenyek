using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gyogynovenyek
{
    class Program
    {
        static List<Noveny> lista = new List<Noveny>();
        static Dictionary<string, int> reszek = new Dictionary<string, int>();
        static void Beolvas()
        {
            StreamReader sr = new StreamReader("noveny.csv");
            while (!sr.EndOfStream)
            {
                lista.Add(new Noveny(sr.ReadLine()));
            }
            sr.Close();
        }
        static void Darabszam()
        {
            Console.WriteLine("1.feladat:\n Növények száma: {0}",lista.Count());
        }
        static void Feladat2()
        {
            Console.WriteLine("\n2.feladat: Gyüjthető részek:");
            foreach (var n in lista)
            {
                if (!reszek.ContainsKey(n.Resz))
                {
                    reszek.Add(n.Resz, 0);
                }
            }
            foreach (var i in lista)
            {
                reszek[i.Resz]++;
            }
            foreach (var r in reszek)
            {
                Console.WriteLine($"{r.Key}: {r.Value}");
            }
        }
        static void Feladat3()
        {
            Console.WriteLine("\n3.feladat:");
            int max = 0;
            string noveny = "";
            foreach (var i in lista)
            {
                if (i.Idotartam > max)
                {
                    max = i.Idotartam;
                    noveny = i.Nev;
                }
            }
            Console.WriteLine("Legtöbb idő amíg gyüjthető {0}.",max);
            Console.WriteLine("Növény(ek): {0}",noveny);
        }
        static void Feladat4()
        {
            double osszeg = 0;
            double atlag = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                osszeg = osszeg + lista[i].Idotartam;
            }
            atlag = osszeg / lista.Count;
            Console.WriteLine("\n4.feladat");
            Console.WriteLine("Átlagos gyüjthető időtartam: {0}",atlag);
        }
        static void Main(string[] args)
        {
            var N = new Noveny("Acsalapu; levél; 6; 8");
            Beolvas();
            Darabszam();
            Feladat2();
            Feladat3();
            Feladat4();

            Console.ReadKey();
   
        }
    }
}
