using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Singleton
    {
        private static Singleton _instance = new Singleton();

        public Uge TempUge { get; set; }
        public Dictionary<string,Object> DenneUge { get; set; }
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

        public void nyUge()
        {
            
            //Persistance.SaveJson(DenneUge,"Uge"+DenneUge.);
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
            DenneUge.Add("uge",ugeX);
            DenneUge.Add("Temp", TempUge);
            Persistance.SaveJson(DenneUge, "Uge" + Dato.GetDenneUge() + ".json");
        }
    }
}
