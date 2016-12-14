
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class UgePlanVM
    {
        private String _ugeNr = "Uge: "+Dato.GetDenneUge();

        public String UgeNr
        {
            get { return _ugeNr; }
            set { _ugeNr = value; }
        }
        private String _ugeNr2 = "Uge: " + Dato.GetNextUge();

        public String UgeNr2
        {
            get { return _ugeNr2; }
            set { _ugeNr = value; }
        }

        public Uge DenneUge { get; set; }

        public UgePlanVM()
        {
            CheckNewWeek();
            DenneUge = Singleton.GetInstance().TempUge;
            UgeNr = DenneUge.StrUgenummer;
        }

        private async void CheckNewWeek()
        {
            try
            {
                Gem Banan = await Persistance.LoadGemFromJsonAsync("Uge" + Dato.GetDenneUge()+ ".json");
                Gem hentet = new Gem();
                hentet = Banan;
                hentet.exportFraGem();
            }
            catch (FileNotFoundException)
            {
                await Singleton.GetInstance().nyUge();
            }
        }
    }
}
