using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Faellesspisning
{
    class Uge
    {
        public DateTime DtUgenummer { get; set; }
        public string StrUgenummer { get; set; }
        public int IntUgenummer { get; set; }

        // Denne klasses konstruktør skal oprettet 4 objekter af klassen Dag. Der indeholder Dagsnavn = Mandag, Tirsdag, osv.
        // Hvor alle de andre felter er tomme.

        public Uge()
        {
            //Psuedo kode
            //Ugenummer = GetWeek;

            Dag mandag = new Dag("Mandag", IntUgenummer);
            Dag tirsdag = new Dag("Tirsdag", IntUgenummer);
            Dag onsdag = new Dag("Onsdag", IntUgenummer);
            Dag torsdag = new Dag("Torsdag", IntUgenummer);
            
            
        } 
    }
}
