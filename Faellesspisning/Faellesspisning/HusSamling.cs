using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class HusSamling
    {
        private static HusSamling _husSamling = new HusSamling();
        private ObservableCollection<Bolig> _huseOc= new ObservableCollection<Bolig>();

        public ObservableCollection<Bolig> HuseOC
        {
            get { return _huseOc; }
            set { _huseOc = value; }
        }

        public HusSamling()
        {
            
        }
        public static HusSamling GetHusSamling()
        { return _husSamling;}

        
    }
}
