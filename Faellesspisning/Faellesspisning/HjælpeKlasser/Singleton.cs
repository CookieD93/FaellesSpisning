using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Faellesspisning;

namespace Faellesspisning
{
    class Singleton
    {
        // Singleton'en sørger for at holde liv i alle de informationer der skal gemmes mellem alle sider
        private static Singleton _instance = new Singleton();
        public Uge DenneTempUge { get; set; }
        public Uge NæsteTempUge { get; set; }
        public Dictionary<int, Bolig> StandardListe { get; set; }
        public List<Arrangement> ArrengementListe { get; set; }
        private Singleton()
        {
          
        }
        public static Singleton GetInstance()
        {
            return _instance;
        }
        public async Task nyNæsteUge()
        {
            Uge ugeX = new Uge();
            NæsteTempUge = ugeX;
            await CheckStandard();
            NæsteTempUge.BoligListe = StandardListe;
            GemUge gem = new GemUge();
            gem.importTilGemNæsteUge();
            Persistance.SaveJson(gem, "Uge" + Dato.GetNæsteUge() + ".json");
        }
        public async Task nyDenneUge()
        {
            Uge ugeX = new Uge();
            DenneTempUge = ugeX;
            DenneTempUge.StrUgenummer = "" + Dato.GetDenneUge();
            DenneTempUge.IntUgenummer = Dato.GetDenneUge();
            await CheckStandard();
            DenneTempUge.BoligListe = StandardListe;
            GemUge gem = new GemUge();
            gem.importTilGemDenneUge();
            Persistance.SaveJson(gem, "Uge" + Dato.GetDenneUge() + ".json");
        }
        public async Task CheckStandard()
        {
            try
            {
                StandardListe = await Persistance.LoadStandardFraJsonAsync("Standard.json");
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
