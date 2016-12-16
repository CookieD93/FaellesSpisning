using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Eventmaker.Common;

namespace Faellesspisning
{
    class MadPlanlaegningViewVM
    {
        private Uge _denneUge;
        private string _dmUdlæg;
        private string _dTiUdlæg;
        private string _doUdlæg;
        private string _dToUdlæg;
        private string _nmUdlæg;
        private string _nTiUdlæg;
        private string _noUdlæg;
        private string _nToUdlæg;
        public RelayCommand GemRetterForDenneUgeRelayCommand { get; set; }
        public RelayCommand GemRetterForNæsteUgeRelayCommand { get; set; }
        public RelayCommand GemArrangementRelayCommand { get; set; }
        public Arrangement ArrangementIPlanlægning { get; set; }
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
        //Udlæg
        public string DMUdlæg
        {
            get { return _dmUdlæg; }
            set { _dmUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg);
            }
        }

        public string DTiUdlæg
        {
            get { return _dTiUdlæg; }
            set { _dTiUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string DOUdlæg
        {
            get { return _doUdlæg; }
            set { _doUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string DToUdlæg
        {
            get { return _dToUdlæg; }
            set { _dToUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string NMUdlæg
        {
            get { return _nmUdlæg; }
            set { _nmUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string NTiUdlæg
        {
            get { return _nTiUdlæg; }
            set { _nTiUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string NOUdlæg
        {
            get { return _noUdlæg; }
            set { _noUdlæg = value; tryParseToDouble(value, NæsteUge.torsdag.Udlæg); }
        }

        public string NToUdlæg
        {
            get { return _nToUdlæg; }
            set { _nToUdlæg = value; tryParseToDouble(value,NæsteUge.torsdag.Udlæg); }
        }

        #endregion

        public Uge DenneUge
        {
            get { return _denneUge; }
            set { _denneUge = value; }
        }

        public Uge NæsteUge { get; set; }

        private void tryParseToDouble(string input, double BindPlace)
        {
            double tal=0;
            double result;

            if (double.TryParse(input, out result)&& double.Parse(input)>0)
            {
                BindPlace = double.Parse(input);
            }

            else
            {
                Persistance.MessageDialogHelper.Show("Udlægget er ikke et tal", "fejl");
            }
        }
            public
            MadPlanlaegningViewVM()
        {
            _denneUge = Singleton.GetInstance().DenneTempUge;
            NæsteUge = Singleton.GetInstance().NæsteTempUge;
            GemRetterForDenneUgeRelayCommand = new RelayCommand(Save);
            GemRetterForNæsteUgeRelayCommand = new RelayCommand(SaveNæste);
            GemArrangementRelayCommand = new RelayCommand(GemArrangement);
 
            ArrangementIPlanlægning = new Arrangement();

            // Psuedo kode:
            // 1. Hvis der ikke er en fil med navnet uge+(getWeek).json så skal der oprettes et object der hedder Uge+(getWeek).
            //      Findes filen, skal denne loades ind i UgePlanlægnings Viewet
        }

        public void GemArrangement()
        {
            Singleton.GetInstance().ArrengementListe.Add(ArrangementIPlanlægning);
            Persistance.SaveJson(Singleton.GetInstance().ArrengementListe,"Arrangementer.json");
            Persistance.MessageDialogHelper.Show("File Saved", "Saved");

        }
        public void Save()
        {
            GemUge gem = new GemUge();
            gem.importTilGemDenneUge();
            Persistance.SaveJson(gem,"Uge"+Dato.GetDenneUge()+".json");
        }public void SaveNæste()
        {
            GemUge gem = new GemUge();
            gem.importTilGemNæsteUge();
            Persistance.SaveJson(gem,"Uge"+Dato.GetNextUge()+".json");
        }
    }
}