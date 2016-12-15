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

        public Uge TempUge { get; set; }
        public Dictionary<int, Bolig> TempListe { get; set; }
        //public Dictionary<string, Object> DenneUge { get; set; }
        public Dictionary<int, Bolig> Boligliste { get; set; }
        public List<Arrangement> ArrengementListe { get; set; }

        //public Dictionary<string,Object> NaesteUge { get; set; }

        private Singleton()
        {

            //DenneUge["uge"]= new Uge();
            //DenneUge = new Dictionary<string, object>();

            //NaesteUge= new Dictionary<string, object>();
        }

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public async Task nyUge()
        {

            //if (DenneUge != null)
            //{
            //    DenneUge.Clear();
            //}
            //DenneUge = NaesteUge;
            //if (NaesteUge != null)
            //{
            //    NaesteUge.Clear();
            //}
            Uge ugeX = new Uge();
            TempUge = ugeX;
            await Standardido();
            Boligliste = TempListe;
            // DenneUge.Add("uge",ugeX);
            Gem gem = new Gem();
            // gem.importTilGem();
            Persistance.SaveJson(gem, "Uge" + Dato.GetDenneUge() + ".json");


        }

        private async Task Standardido()
        {
            try
            {
                TempListe = await Persistance.LoadStandardFromJsonAsync("Standard.json");

            }
            catch (FileNotFoundException ex)
            {
                Dictionary<int, Bolig> tempListeTilOprettelseAfStandard= new Dictionary<int, Bolig>();

                for (int i = 72; i <= 116; i=i+2)
                {
                    tempListeTilOprettelseAfStandard.Add(i, new Bolig(i));
                }
                Persistance.SaveJson(tempListeTilOprettelseAfStandard, "Standard.json");
                TempListe = tempListeTilOprettelseAfStandard;
            }
            
        }
    }
}
