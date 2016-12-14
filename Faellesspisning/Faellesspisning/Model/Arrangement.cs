using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Arrangement
    {
        public DateTime Dato { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public bool ErArrangementPrivat { get; set; }
        public double Udlæg { get; set; }

        public string Note { get; set; }

        public Arrangement()
        {
            Dato = DateTime.Today;
            Titel = "";
            Beskrivelse = "";
            ErArrangementPrivat = false;
            Udlæg = 0;
            Note = "";
        }



    }
}
