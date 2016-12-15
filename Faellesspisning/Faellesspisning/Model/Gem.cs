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

        public Dictionary<int,Bolig> GemtBoligliste { get; set; }

        public Gem()
        {
            
        }
        public void importTilGem(Uge HvilkenUge)
        {
            GemtUge = HvilkenUge;
            GemtBoligliste = Singleton.GetInstance().Boligliste;
        }

        public void exportFraGemNæsteUge()
        {
            Singleton.GetInstance().NæsteTempUge = GemtUge;
            Singleton.GetInstance().Boligliste = GemtBoligliste;
        }
        public void exportFraGemDenneUge()
        {
            Singleton.GetInstance().DenneTempUge = GemtUge;
            Singleton.GetInstance().Boligliste = GemtBoligliste;
        }
    }
}
