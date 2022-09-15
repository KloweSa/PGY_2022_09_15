using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    internal class Space
    {
        private string kuldKod;
        private string sikloDatum;
        private string sikloNev;
        private int nap;
        private int ora;
        private string tamaszPont;
        private int legenyseg;

        public string KuldKod { get => kuldKod; set => kuldKod = value; }
        public string SikloDatum { get => sikloDatum; set => sikloDatum = value; }
        public string SikloNev { get => sikloNev; set => sikloNev = value; }
        public int Nap { get => nap; set => nap = value; }
        public int Ora { get => ora; set => ora = value; }
        public string TamaszPont { get => tamaszPont; set => tamaszPont = value; }
        public int Legenyseg { get => legenyseg; set => legenyseg = value; }

        public Space(string sor)
        {
            string[] darabok = sor.Split(';');

            KuldKod = darabok[0];
            SikloDatum = darabok[1];
            SikloNev = darabok[2];
            Nap = Convert.ToInt32(darabok[3]);
            Ora = Convert.ToInt32(darabok[4]);
            TamaszPont = darabok[5];
            Legenyseg = Convert.ToInt32(darabok[6]);
        }
    }
}
