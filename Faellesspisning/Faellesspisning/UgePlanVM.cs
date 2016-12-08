using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class UgePlanVM
    {
        // En constructer der laver et nyt object af en klassen Uge
        // Denne skal så hente alle data fra Bolig klassen, og gemme det i List/Dictionary/OC
        // Dette Uge object skal enten automatisk oprettes ved begyndelsen på en ny uge[1], eller ved en "manuel" knap på UgePlanLægnings View
        public UgePlanVM()
        {
            CheckNewWeek();
        }

        private void CheckNewWeek()
        {
            try
            {
                Persistance.LoadFromJsonAsync("Uge" + Dato.GetDenneUge() + ".json");
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
