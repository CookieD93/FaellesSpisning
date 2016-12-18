using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Eventmaker.Common;
using Faellesspisning;

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
        #region Props til Databinding
        //Ikke Brugte Props
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
            set
            {
                _dmUdlæg = value;
                DenneUge.mandag.Udlæg= tryParseToDouble(value);
            }
        }
        public string DTiUdlæg
        {
            get { return _dTiUdlæg; }
            set
            {
                _dTiUdlæg = value;
                DenneUge.tirsdag.Udlæg=tryParseToDouble(value);
            }
        }
        public string DOUdlæg
        {
            get { return _doUdlæg; }
            set
            {
                _doUdlæg = value;
                DenneUge.onsdag.Udlæg=tryParseToDouble(value);
            }
        }
        public string DToUdlæg
        {
            get { return _dToUdlæg; }
            set
            {
                _dToUdlæg = value;
                DenneUge.torsdag.Udlæg=tryParseToDouble(value);
            }
        }
        public string NMUdlæg
        {
            get { return _nmUdlæg; }
            set
            {
                _nmUdlæg = value;
                NæsteUge.mandag.Udlæg=tryParseToDouble(value);
            }
        }
        public string NTiUdlæg
        {
            get { return _nTiUdlæg; }
            set
            {
                _nTiUdlæg = value;
                NæsteUge.tirsdag.Udlæg=tryParseToDouble(value);
            }
        }
        public string NOUdlæg
        {
            get { return _noUdlæg; }
            set
            {
                _noUdlæg = value;
                NæsteUge.onsdag.Udlæg=tryParseToDouble(value);
            }
        }
        public string NToUdlæg
        {
            get { return _nToUdlæg; }
            set
            {
                _nToUdlæg = value;
                NæsteUge.torsdag.Udlæg=tryParseToDouble(value);
            }
        }
        #endregion
        public Uge DenneUge
        {
            get { return _denneUge; }
            set { _denneUge = value; }
        }
        public Uge NæsteUge { get; set; }
        private double tryParseToDouble(string input)
        {
            double result;
            if (double.TryParse(input, out result) && double.Parse(input) > 0)
            {
               return result;
            }   
                Persistance.MessageDialogHelper.Show(@"Udlægget er ikke et tal, der vil derfor blive gemt et udlæg på 0 hvis der bliver trykket ""Gem"" ", "fejl");
                return 0;
        }
        public MadPlanlaegningViewVM()
        {
            _denneUge = Singleton.GetInstance().DenneTempUge;
            NæsteUge = Singleton.GetInstance().NæsteTempUge;
            GemRetterForDenneUgeRelayCommand = new RelayCommand(SaveUge);
            GemRetterForNæsteUgeRelayCommand = new RelayCommand(SaveNæsteUge);
            GemArrangementRelayCommand = new RelayCommand(GemArrangement);
            ArrangementIPlanlægning = new Arrangement();
        }
        public void GemArrangement()
        {
            Singleton.GetInstance().ArrengementListe.Add(ArrangementIPlanlægning);
            Persistance.SaveJson(Singleton.GetInstance().ArrengementListe, "Arrangementer.json");
            Persistance.MessageDialogHelper.Show("File Saved", "Saved");

        }
        public void SaveUge()
        {
            GemUge gem = new GemUge();
            gem.importTilGemDenneUge();
            Persistance.SaveJson(gem,"Uge"+Dato.GetDenneUge()+".json");
        }
        public void SaveNæsteUge()
        {
            GemUge gem = new GemUge();
            gem.importTilGemNæsteUge();
            Persistance.SaveJson(gem,"Uge"+Dato.GetNæsteUge()+".json");
        }
    }
}