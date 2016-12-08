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

        // En constructer der laver et nyt object af en klassen Uge
        // Denne skal så hente alle data fra Bolig klassen, og gemme det i List/Dictionary/OC
        // Dette Uge object skal enten automatisk oprettes ved begyndelsen på en ny uge[1], eller ved en "manuel" knap på UgePlanLægnings View
        public UgePlanVM()
        {
            CheckNewWeek();
            
        }

        private async void CheckNewWeek()
        {
            //Dictionary<string,Object> DenneUge = await Persistance.LoadFromJsonAsync("Uge" + Dato.GetDenneUge() + ".json");

            try
            {
                Dictionary<string, Object> Banan = await Persistance.LoadFromJsonAsync("Uge" + Dato.GetDenneUge()+ ".json");
                Singleton.GetInstance().DenneUge = Banan;
            }
            catch (FileNotFoundException)
            {
                Singleton.GetInstance().nyUge();
            }
        }

        // Psuedo kode:
        // 1. Hvis der ikke er en fil med navnet uge+(getWeek).json så skal der oprettes et object der hedder Uge+(getWeek).
        //      Findes filen, skal denne loades ind i UgePlanlægnings Viewet
    }
}
