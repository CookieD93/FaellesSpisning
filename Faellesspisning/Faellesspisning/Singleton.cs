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
        public Dictionary<string, Object> DenneUge { get; set; }
        public Dictionary<int, Bolig> Boligliste { get; set; }
        //public Dictionary<string,Object> NaesteUge { get; set; }

        private Singleton()
        {

            //DenneUge["uge"]= new Uge();
            DenneUge = new Dictionary<string, object>();

            //NaesteUge= new Dictionary<string, object>();
        }

        public static Singleton GetInstance()
        {
            return _instance;
        }

        public async Task nyUge()
        {

            if (DenneUge != null)
            {
                DenneUge.Clear();
            }
            //DenneUge = NaesteUge;
            //if (NaesteUge != null)
            //{
            //    NaesteUge.Clear();
            //}
            Uge ugeX = new Uge();
            TempUge = ugeX;
            try
            {
                await Standardido();

            }
            catch (FileNotFoundException)
            {
                
                throw new NotImplementedException("Standard filen findes ikke(endnu), Den ligger i Repo mappen. \n Den skal ind og ligge i % appdata % mappen");
            }
            Boligliste = TempListe;
           // DenneUge.Add("uge",ugeX);
            Gem gem = new Gem();
           // gem.importTilGem();
            Persistance.SaveJson(gem, "Uge" + Dato.GetDenneUge() + ".json");


        }

        private async Task Standardido()
        {
            
            TempListe = await Persistance.LoadStandardFromJsonAsync("Standard.json");
            
        }
    }
}
