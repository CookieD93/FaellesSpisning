using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation;

namespace Faellesspisning
{

    class Bolig
    {
        public int BoligNr { get; set; }
        public List<int> DaglistMan { get; set; }
        public List<int> DaglistTir { get; set; }
        public List<int> DaglistOns { get; set; }
        public List<int> DaglistTor { get; set; }
        public Bolig(int boligNr)
        {
            BoligNr = boligNr;
            //UgeList = new List<List<int>>();
            //_standarder = int[4, 4];
            DaglistMan = new List<int>();
            DaglistTir = new List<int>();
            DaglistOns = new List<int>();
            DaglistTor = new List<int>();

            

            for (int i = 0; i < 4; i++)
            {
               
                
                DaglistMan.Add(0);
                DaglistTir.Add(0);
                DaglistOns.Add(0);
                DaglistTor.Add(0);
               

            }
            
            
            
            
        }
    }
}
