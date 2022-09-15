using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Space> siklo = new List<Space>();

            FileStream fs = new FileStream("kuldetesek.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                Space s = new Space(sr.ReadLine());
                siklo.Add(s);
            }


            sr.Close();
            fs.Close();

            //-------------

            Console.WriteLine("3. feladat:");
            Console.WriteLine("\tÖsszesen {0} alkalommal indítottak űrhajót.", siklo.Count);

            //-------------

            int utasok = 0;
            for (int i = 0; i < siklo.Count; i++)
            {
                utasok += siklo[i].Legenyseg;
            }

            Console.WriteLine("4. feladat:");
            Console.WriteLine("\t{0} utas indult az űrbe összesen.", utasok);

            //-------------

            int kevesebb = 0;
            for (int i = 0; i < siklo.Count; i++)
            {
                if (siklo[i].Legenyseg < 5) kevesebb++;
            }

            Console.WriteLine("5. feladat:");
            Console.WriteLine("\tÖsszesen {0} alkalommal küldtek kevesebb, mint 5 embert az űrbe.", kevesebb);

            //-------------

            int columbia = 0;
            for (int i = 0; i < siklo.Count; i++)
            {
                if (siklo[i].SikloNev == "Columbia") columbia = i;
            }

            Console.WriteLine("6. feladat:");
            Console.WriteLine("\t{0} asztronauta volt a Columbia fedélzetén annak utolsó útján.", siklo[columbia].Legenyseg);

            //-------------

            int index = 0;
            int max = (siklo[0].Nap * 24) + siklo[0].Ora;        

            for (int i = 0; i < siklo.Count; i++)
            {
                if((siklo[i].Nap * 24) + siklo[i].Ora > max)
                {
                    max = (siklo[i].Nap * 24) + siklo[i].Ora;
                    index = i;
                }
            }         

            Console.WriteLine("7. feladat:");
            Console.WriteLine("\tA leghosszabb ideig a {0} volt az űrben {1} küldetés során.", siklo[index].SikloNev, siklo[index].KuldKod);
            Console.WriteLine("\tÖsszesen {0} órát volt távol a Földtől.", max);

            //-------------

            Console.WriteLine("8. feladat:");
            Console.Write("\tÉvszám: ");
            int evszam = Convert.ToInt32(Console.ReadLine());
            int kuldi = 0;

            for (int i = 0; i < siklo.Count; i++)
            {
                string[] ev = siklo[i].SikloDatum.Split('.');
                if (ev[0] == Convert.ToString(evszam)) kuldi++;
            }

            if (kuldi == 0) Console.WriteLine("\tEbben az évben nem indult küldetés");
            else Console.WriteLine("\tEbben az évben {0} küldetés volt.", kuldi);

            //-------------

            Console.WriteLine("9. feladat:");

            double kennedy = 0;
            for (int i = 0; i < siklo.Count; i++)
            {
                if (siklo[i].TamaszPont == "Kennedy") kennedy++;
            }

            double szazalek = kennedy / siklo.Count;
            szazalek = szazalek * 100;
            Console.WriteLine("\tA küldetések {0}%-a fejeződött be az Kennedy űrközpontban.", Math.Round(szazalek, 2));

            //-------------

            fs = new FileStream("ursiklok.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            int uColumbia = 0;
            int uChallanger = 0;
            int uDiscovery = 0;
            int uAtlantis = 0;
            int uEnd = 0;
            /*for (int i = 0; i < siklo.Count; i++)
            {
                if (siklo[i].SikloNev == "Columbia") uColumbia++;
                else if (siklo[i].SikloNev == "Challanger") uChallanger++;
                else if (siklo[i].SikloNev == "Challanger") uChallanger++;
            }

            for (int i = 0; i < siklo.Count; i++)
            {
                sw.WriteLine();
            }*/

            sw.Close();
            fs.Close();

            Console.ReadKey();           
        }
    }
}