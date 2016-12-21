

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Faellesspisning;

namespace Faellesspisning
{
    class UgePlanVM
    {
        private String _ugeNr = "Uge: " + Dato.GetDenneUge();
        public String UgeNr
        {
            get { return _ugeNr; }
            set { _ugeNr = value; }
        }
        private String _ugeNr2 = "Uge: " + Dato.GetNæsteUge();
        public String UgeNr2
        {
            get { return _ugeNr2; }
            set { _ugeNr = value; }
        }
        public Uge DenneUge { get; set; }
        public Uge NæsteUge { get; set; }
        public string DeltagereMandag => Singleton.GetInstance().DenneTempUge.deltagereMandag();
        public string DeltagereTirsdag => Singleton.GetInstance().DenneTempUge.deltagereTirsdag();
        public string DeltagereOnsdag => Singleton.GetInstance().DenneTempUge.deltagereOnsdag();
        public string DeltagereTorsdag => Singleton.GetInstance().DenneTempUge.deltagereTorsdag();
        public string DeltagereMandagNæsteUge => Singleton.GetInstance().NæsteTempUge.deltagereMandag();
        public string DeltagereTirsdagNæsteUge => Singleton.GetInstance().NæsteTempUge.deltagereTirsdag();
        public string DeltagereOnsdagNæsteUge => Singleton.GetInstance().NæsteTempUge.deltagereOnsdag();
        public string DeltagereTorsdagNæsteUge => Singleton.GetInstance().NæsteTempUge.deltagereTorsdag();
        public UgePlanVM()
        {
            Boot();
            DenneUge = Singleton.GetInstance().DenneTempUge;
            NæsteUge = Singleton.GetInstance().NæsteTempUge;
        }
        public async Task Boot()
        {
            await CheckNewWeek();
            DenneUge = Singleton.GetInstance().DenneTempUge;
            await Task.Delay(500);
            NæsteUge = Singleton.GetInstance().NæsteTempUge;
            CheckArrangement();
        }
        private async Task CheckNewWeek()
        {
            try
            {
                GemUge SavedJsonClass = await Persistance.LoadUgeFraJsonAsync("Uge" + Dato.GetDenneUge() + ".json");
                GemUge hentet = new GemUge();
                hentet = SavedJsonClass;
                hentet.exportFraGemDenneUge();
            }
            catch (FileNotFoundException)
            {
                Persistance.MessageDialogHelper.Show("Ingen fil for denne uge fundet, der vil derfor blive oprettet en tom uge","No current week");
                await Singleton.GetInstance().nyDenneUge();
            }
            try
            {
                GemUge SavedJsonClass= await Persistance.LoadUgeFraJsonAsync("Uge" + Dato.GetNæsteUge() + ".json");
                GemUge hentet = new GemUge();
                hentet = SavedJsonClass;
                hentet.exportFraGemNæsteUge();
            }
            catch (FileNotFoundException)
            {
                await Singleton.GetInstance().nyNæsteUge();
            }
        }
        private async void CheckArrangement()
        {
            try
            {
                List<Arrangement> SavedJsonArrangementer = await Persistance.LoadArrangementFraJsonAsync("Arrangementer.json");
                Singleton.GetInstance().ArrengementListe = SavedJsonArrangementer;
            }
            catch (FileNotFoundException)
            {
                Singleton.GetInstance().ArrengementListe = new List<Arrangement>();
                Persistance.SaveJson(Singleton.GetInstance().ArrengementListe,"Arrangementer.json");
            }
        }
    }
}
