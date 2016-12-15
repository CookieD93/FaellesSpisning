using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Windows.Storage.FileProperties;

namespace Faellesspisning
{
    class Uge
    {
        public DateTime DtUgenummer { get; set; }
        public string StrUgenummer { get; set; }
        public int IntUgenummer { get; set; }
        public Dag mandag { get; set; }
        public Dag tirsdag { get; set; }
        public Dag onsdag { get; set; }
        public Dag torsdag { get; set; }


        // Denne klasses konstruktør skal oprettet 4 objekter af klassen Dag. Der indeholder Dagsnavn = Mandag, Tirsdag, osv.
        // Hvor alle de andre felter er tomme.

        public Uge()
        {
            StrUgenummer = "Uge"+Dato.GetNextUge();
            //Psuedo kode
            //Ugenummer = GetWeek;
            IntUgenummer = Dato.GetNextUge();

            mandag = new Dag("Mandag", IntUgenummer);
            tirsdag = new Dag("Tirsdag", IntUgenummer);
            onsdag = new Dag("Onsdag", IntUgenummer);
            torsdag = new Dag("Torsdag", IntUgenummer);
            
            
        } 
    }
}
