using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Gem
    {
        public Uge GemtUge { get; set; }

       // public Dictionary<int,Bolig> GemtBoligliste { get; set; }

        public Gem()
        {
            
        }
        //Har lagt BoligListerne ind under Ugen. På den måde skal vi "bare" gemme ugen.
        public void importTilGemNæsteUge()
        {
            GemtUge = Singleton.GetInstance().NæsteTempUge;
           // GemtBoligliste = Singleton.GetInstance().NæsteTempUge.BoligListe;
        }public void importTilGemDenneUge()
        {
            GemtUge = Singleton.GetInstance().DenneTempUge;
            //GemtBoligliste = Singleton.GetInstance().DenneTempUge.BoligListe;
        }

        public void exportFraGemNæsteUge()
        {
            Singleton.GetInstance().NæsteTempUge = GemtUge;
          //  Singleton.GetInstance().NæsteTempUge.BoligListe = GemtBoligliste;
        }
        public void exportFraGemDenneUge()
        {
            Singleton.GetInstance().DenneTempUge = GemtUge;
           // Singleton.GetInstance().DenneTempUge.BoligListe = GemtBoligliste;
        }
    }
}
