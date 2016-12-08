using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class MadPlanlaegningViewVM
    {
        private Uge _uge;
        // En constructer der laver et nyt object af en klassen Uge
        // Denne skal så hente alle data fra Bolig klassen, og gemme det i List/Dictionary/OC
        // Dette Uge object skal enten automatisk oprettes ved begyndelsen på en ny uge[1], eller ved en "manuel" knap på UgePlanLægnings View
        #region Props til Databinding
        //Ret
        //public string DMRet { get; set; }
        //public string DTiRet { get; set; }
        //public string DORet { get; set; }
        //public string DToRet { get; set; }
        //public string NMRet { get; set; }
        //public string NTiRet { get; set; }
        //public string NORet { get; set; }
        //public string NToRet { get; set; }
        ////Chef Kok
        //public string DMCKok { get; set; }
        //public string DTiCKok { get; set; }
        //public string DOCKok { get; set; }
        //public string DToCKok { get; set; }
        //public string NMCKok { get; set; }
        //public string NTiCKok { get; set; }
        //public string NOCKok { get; set; }
        //public string NToCKok { get; set; }
        ////Hjælpe Kokke
        //public string DMHKok { get; set; }
        //public string DTiHKok { get; set; }
        //public string DOHKok { get; set; }
        //public string DToHKok { get; set; }
        //public string NMHKok { get; set; }
        //public string NTiHKok { get; set; }
        //public string NOHKok { get; set; }
        //public string NToHKok { get; set; }
        ////Opryddere
        //public string DMOpryd { get; set; }
        //public string DTiOpryd { get; set; }
        //public string DOOpryd { get; set; }
        //public string DToOpryd { get; set; }
        //public string NMOpryd { get; set; }
        //public string NTiOpryd { get; set; }
        //public string NOOpryd { get; set; }
        //public string NToOpryd { get; set; }
        ////Note
        //public string DMNote { get; set; }
        //public string DTiNote { get; set; }
        //public string DONote { get; set; }
        //public string DToNote { get; set; }
        //public string NMNote { get; set; }
        //public string NTiNote { get; set; }
        //public string NONote { get; set; }
        //public string NToNote { get; set; }
        ////Udlæg
        //public string DMUdlæg { get; set; }
        //public string DTiUdlæg { get; set; }
        //public string DOUdlæg { get; set; }
        //public string DToUdlæg { get; set; }
        //public string NMUdlæg { get; set; }
        //public string NTiUdlæg { get; set; }
        //public string NOUdlæg { get; set; }
        //public string NToUdlæg { get; set; } 
        #endregion

        public Uge uge
        {
            get { return _uge; }
            set { _uge = value; }
        }

        public MadPlanlaegningViewVM()
        {
            _uge = (Uge)Singleton.GetInstance().DenneUge["uge"];
            
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

        public void Save()
        {
            Singleton.GetInstance().DenneUge["uge"] = _uge;
        }
    }
}
