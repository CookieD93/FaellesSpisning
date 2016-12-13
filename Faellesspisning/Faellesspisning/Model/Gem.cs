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
            importTilGem();
        }
        public void importTilGem()
        {
            GemtUge = Singleton.GetInstance().TempUge;
            GemtBoligliste = Singleton.GetInstance().Boligliste;
        }

        public void exportFraGem()
        {
            Singleton.GetInstance().TempUge = GemtUge;
            Singleton.GetInstance().Boligliste = GemtBoligliste;
        }
    }
}
