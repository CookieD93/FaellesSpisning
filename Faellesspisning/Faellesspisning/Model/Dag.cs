using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Dag
    {
        public int Ugenummer { get; set; }
        public string DagsNavn { get; set; }
        public string Ret { get; set; }
        public string ChefKok { get; set; }
        public int ChefKokHusNr { get; set; }
        public string Kokke { get; set; }
        public string Opryddere { get; set; }
        public double Udlæg { get; set; }
        public string Note { get; set; }

        public Dag(string dagsNavn, int ugenummer)
        {
            Ugenummer = ugenummer;
            DagsNavn = dagsNavn;
            Ret = "";
            ChefKok = "";
            ChefKokHusNr = 0;
            Kokke = "";
            Opryddere = "";
            Udlæg = 0.0;
            Note = "";
        }
        
    }
}
