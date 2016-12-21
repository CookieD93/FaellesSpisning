

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
        private String _ugeNr2 = "Uge: " + Dato.GetN�steUge();
        public String UgeNr2
        {
            get { return _ugeNr2; }
            set { _ugeNr = value; }
        }
        public Uge DenneUge { get; set; }
        public Uge N�steUge { get; set; }
        public string DeltagereMandag => Singleton.GetInstance().DenneTempUge.deltagereMandag();
        public string DeltagereTirsdag => Singleton.GetInstance().DenneTempUge.deltagereTirsdag();
        public string DeltagereOnsdag => Singleton.GetInstance().DenneTempUge.deltagereOnsdag();
        public string DeltagereTorsdag => Singleton.GetInstance().DenneTempUge.deltagereTorsdag();
        public string DeltagereMandagN�steUge => Singleton.GetInstance().N�steTempUge.deltagereMandag();
        public string DeltagereTirsdagN�steUge => Singleton.GetInstance().N�steTempUge.deltagereTirsdag();
        public string DeltagereOnsdagN�steUge => Singleton.GetInstance().N�steTempUge.deltagereOnsdag();
        public string DeltagereTorsdagN�steUge => Singleton.GetInstance().N�steTempUge.deltagereTorsdag();
        public UgePlanVM()
        {
            Boot();
            DenneUge = Singleton.GetInstance().DenneTempUge;
            N�steUge = Singleton.GetInstance().N�steTempUge;
        }
        public async Task Boot()
        {
            await CheckNewWeek();
            DenneUge = Singleton.GetInstance().DenneTempUge;
            await Task.Delay(500);
            N�steUge = Singleton.GetInstance().N�steTempUge;
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
                GemUge SavedJsonClass= await Persistance.LoadUgeFraJsonAsync("Uge" + Dato.GetN�steUge() + ".json");
                GemUge hentet = new GemUge();
                hentet = SavedJsonClass;
                hentet.exportFraGemN�steUge();
            }
            catch (FileNotFoundException)
            {
                await Singleton.GetInstance().nyN�steUge();
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
