using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Faellesspisning
{
    class Singleton
    {
        private static Singleton _instance = new Singleton();

        public Uge DenneTempUge { get; set; }
        public Uge NæsteTempUge { get; set; }
        public Dictionary<int, Bolig> StandardListe { get; set; }
        //public Dictionary<string, Object> DenneUge { get; set; }
              // public Dictionary<int, Bolig> Boligliste { get; set; }
        public List<Arrangement> ArrengementListe { get; set; }

        //public Dictionary<string,Object> NaesteUge { get; set; }

        private Singleton()
        {
          // Standardido();
            //DenneUge["uge"]= new Uge();
            //DenneUge = new Dictionary<string, object>();

            //NaesteUge= new Dictionary<string, object>();
        }

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public async Task nyNæsteUge()
        {
            Uge ugeX = new Uge();
            NæsteTempUge = ugeX;
            await Standardido();
            NæsteTempUge.BoligListe = StandardListe;
            GemUge gem = new GemUge();
            gem.importTilGemNæsteUge();
            Persistance.SaveJson(gem, "Uge" + Dato.GetNextUge() + ".json");
        }
        public async Task nyDenneUge()
        {
            Uge ugeX = new Uge();
            DenneTempUge = ugeX;
            await Standardido();
            DenneTempUge.BoligListe = StandardListe;
            GemUge gem = new GemUge();
            gem.importTilGemDenneUge();
            Persistance.SaveJson(gem, "Uge" + Dato.GetDenneUge() + ".json");
        }
        //Næste uge onsdag skulle vise banan
        private async Task Standardido()
        {
            try
            {
                StandardListe = await Persistance.LoadStandardFromJsonAsync("Standard.json");

            }
            catch (FileNotFoundException)
            {
                Dictionary<int, Bolig> tempListeTilOprettelseAfStandard= new Dictionary<int, Bolig>();

                for (int i = 72; i <= 116; i=i+2)
                {
                    tempListeTilOprettelseAfStandard.Add(i, new Bolig(i));
                }
                Persistance.SaveJson(tempListeTilOprettelseAfStandard, "Standard.json");
                StandardListe = tempListeTilOprettelseAfStandard;
            }
            
        }
    }
}
