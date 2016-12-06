using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Bolig
    {
        public int BoligNr { get; set; }
        public int[,] Standard { get; set; }

        public Bolig(int boligNr)
        {
            BoligNr = boligNr;
            Standard = new int[4,4];
            
        }

    }
}
