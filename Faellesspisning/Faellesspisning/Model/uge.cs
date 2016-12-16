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

        public Dictionary<int,Bolig> BoligListe { get; set; }

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

        public string deltagereMandag()
        {
            int voksne=new int();
            int unge= new int();
            int børn=new int();
            int småbørn=new int();
            foreach (KeyValuePair<int, Bolig> bolig in BoligListe)
            {
                voksne += bolig.Value.DaglistMan[0];
                unge += bolig.Value.DaglistMan[1];
                børn += bolig.Value.DaglistMan[2];
                småbørn += bolig.Value.DaglistMan[3];
            }

            string result = $"Voksne: {voksne}, Unge: {unge}, Børn: {børn}, Småbørn: {småbørn}";
            return result;
        }
        public string deltagereTirsdag()
        {
            int voksne=new int();
            int unge= new int();
            int børn=new int();
            int småbørn=new int();
            foreach (KeyValuePair<int, Bolig> bolig in BoligListe)
            {
                voksne += bolig.Value.DaglistTir[0];
                unge += bolig.Value.DaglistTir[1];
                børn += bolig.Value.DaglistTir[2];
                småbørn += bolig.Value.DaglistTir[3];
            }

            string result = $"Voksne: {voksne}, Unge: {unge}, Børn: {børn}, Småbørn: {småbørn}";
            return result;
        }public string deltagerOnsdag()
        {
            int voksne=new int();
            int unge= new int();
            int børn=new int();
            int småbørn=new int();
            foreach (KeyValuePair<int, Bolig> bolig in BoligListe)
            {
                voksne += bolig.Value.DaglistOns[0];
                unge += bolig.Value.DaglistOns[1];
                børn += bolig.Value.DaglistOns[2];
                småbørn += bolig.Value.DaglistOns[3];
            }

            string result = $"Voksne: {voksne}, Unge: {unge}, Børn: {børn}, Småbørn: {småbørn}";
            return result;
        }
        public string deltagereTorsdag()
        {
            int voksne=new int();
            int unge= new int();
            int børn=new int();
            int småbørn=new int();
            foreach (KeyValuePair<int, Bolig> bolig in BoligListe)
            {
                voksne += bolig.Value.DaglistTor[0];
                unge += bolig.Value.DaglistTor[1];
                børn += bolig.Value.DaglistTor[2];
                småbørn += bolig.Value.DaglistTor[3];
            }

            string result = $"Voksne: {voksne}, Unge: {unge}, Børn: {børn}, Småbørn: {småbørn}";
            return result;
        }
    }
}
