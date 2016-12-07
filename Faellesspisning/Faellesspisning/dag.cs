using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Dag // : uge
    {
        public string DagsNavn { get; set; }
        public string Ret { get; set; }
        public string ChefKok { get; set; }
        public int ChefKokHusNr { get; set; }
        public string Kokke { get; set; }
        public string Opryddere { get; set; }
        public double Udlæg { get; set; }
    }
}
