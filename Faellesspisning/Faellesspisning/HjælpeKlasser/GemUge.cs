using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class GemUge
    {
        public Uge GemtUge { get; set; }
        public GemUge()
        {
            
        }
        public void importTilGemNæsteUge()
        {
            GemtUge = Singleton.GetInstance().NæsteTempUge;
        }
        public void importTilGemDenneUge()
        {
            GemtUge = Singleton.GetInstance().DenneTempUge;
        }
        public void exportFraGemNæsteUge()
        {
            Singleton.GetInstance().NæsteTempUge = GemtUge;
        }
        public void exportFraGemDenneUge()
        {
            Singleton.GetInstance().DenneTempUge = GemtUge;
        }
    }
}
