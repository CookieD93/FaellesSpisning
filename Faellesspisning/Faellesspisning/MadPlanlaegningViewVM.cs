using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class MadPlanlaegningViewVM
    {
        // En constructer der laver et nyt object af en klassen Uge
        // Denne skal så hente alle data fra Bolig klassen, og gemme det i List/Dictionary/OC
        // Dette Uge object skal enten automatisk oprettes ved begyndelsen på en ny uge[1], eller ved en "manuel" knap på UgePlanLægnings View


        public MadPlanlaegningViewVM()
        {
            // Psuedo kode:
            // 1. Hvis der ikke er en fil med navnet uge+(getWeek).json så skal der oprettes et object der hedder Uge+(getWeek).
            //      Findes filen, skal denne loades ind i UgePlanlægnings Viewet



            // Psuedo
            // try
            // {
            //      Åben filen "Uge + getNextWeek"
            //      Foreach filens indhold ind i en List/Dic/OC
            //      
            // }
            // catch (Exception FileNotFound)
            // {
            //    Hvis filen med det navn ikke findes:
            //    Lav et nyt Uge object med "Uge + getNextWeek"
            // }
        }
    }
}
