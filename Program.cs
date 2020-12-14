using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201214
{
    struct Merkozes
    {
        public string Hazai;
        public string Idegen;
        public int HazaiPont;
        public int IdegenPont;
        public string Helyszin;
        public DateTime Idopont;

        public Merkozes(string sor)
        {
            var t = sor.Split(';');

            Hazai = t[0];
            Idegen = t[1];
            HazaiPont = int.Parse(t[2]);
            IdegenPont = int.Parse(t[3]);
            Helyszin = t[4];

            t = t[5].Split('-');
            Idopont = new DateTime(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
        }
    }

    class Program
    {
        static List<Merkozes> merkozesek = new List<Merkozes>();

        static void Main()
        {
            Beolvas();
            F3();
            F4();
            F5();
            F6();
            F7();
            Console.ReadKey(true);
        }

        private static void F7()
        {
            Console.WriteLine("7. feladat:");
            Dictionary<string, int> merkozesekSzama = new Dictionary<string, int>();
            foreach (var m in merkozesek)
            {
                if (!merkozesekSzama.ContainsKey(m.Helyszin)) merkozesekSzama.Add(m.Helyszin, 1);
                else merkozesekSzama[m.Helyszin]++;
            }
            foreach (var s in merkozesekSzama)
            {
                if (s.Value > 20) Console.WriteLine($"\t{s.Key}: {s.Value}");
            }
        }

        private static void F6()
        {
            Console.WriteLine("6. feladat:");
            DateTime ido = new DateTime(2004, 11, 21);
            foreach (var m in merkozesek)
            {
                if (m.Idopont == ido) Console.WriteLine($"\t{m.Hazai} {m.Idegen} ({m.HazaiPont}:{m.IdegenPont})");
            }
        }

        private static void F5()
        {
            //Palau Blaugrana -> Barcelonai stadion
            //a feladat szövege alapján feltételezhető, hogy biztosan van ilyen csapat
            int i = 0;
            while (merkozesek[i].Helyszin != "Palau Blaugrana" && !merkozesek[i].Hazai.Contains("Barcelona"))
            {
                i++;
            }
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {merkozesek[i].Hazai}");
        }

        private static void F4()
        {
            int i = 0;
            while (i < merkozesek.Count && merkozesek[i].HazaiPont != merkozesek[i].IdegenPont)
            {
                i++;
            }
            if (i < merkozesek.Count) Console.WriteLine("4. feladat: Volt döntetlen? igen");
            else Console.WriteLine("4. feladat: Volt döntetlen? nem");
        }

        private static void F3()
        {
            int h = 0, i = 0;
            for (int j = 0; j < merkozesek.Count; j++)
            {
                if (merkozesek[j].Hazai == "Real Madrid") h++;
                else if (merkozesek[j].Idegen == "Real Madrid") i++;
            }
            Console.WriteLine($"3. feladat: Real Madrid: Hazai {h}, Idegen: {i}");
        }

        private static void Beolvas()
        {
            var sr = new StreamReader(@"..\..\Res\eredmenyek.csv");
            bool kihagy = true;
            while (!sr.EndOfStream)
            {
                if (kihagy)
                {
                    kihagy = false;
                    sr.ReadLine();
                }
                merkozesek.Add(new Merkozes(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
