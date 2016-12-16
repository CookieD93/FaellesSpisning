

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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

        private String _ugeNr2 = "Uge: " + Dato.GetNextUge();

        public String UgeNr2
        {
            get { return _ugeNr2; }
            set { _ugeNr = value; }
        }

        public Uge DenneUge { get; set; }
        public Uge NæsteUge { get; set; }

        public UgePlanVM()
        {
            Boot();
        }
        //Indsæt await på singletons 
        public async Task Boot()
        {
            await CheckNewWeek();
           // await Task.Delay(500);
            DenneUge = Singleton.GetInstance().DenneTempUge;
            await Task.Delay(500);
            NæsteUge = Singleton.GetInstance().NæsteTempUge;
            //await Task.Delay(500);
            CheckArrangement();
        }
        private async Task CheckNewWeek()
        {
            try
            {
                GemUge SavedJsonClass = await Persistance.LoadGemFromJsonAsync("Uge" + Dato.GetDenneUge() + ".json");
                GemUge hentet = new GemUge();
                hentet = SavedJsonClass;
                hentet.exportFraGemDenneUge();
            }
            catch (FileNotFoundException)
            {

                Persistance.MessageDialogHelper.Show("Ingen fil for denne uge fundet, der vil derfor blive oprettet en tom uge","No current week");
                //Denne her linje giver en Access Denied exception hvis den bliver kørt uden nogen som helst filer (clean run)
                await Singleton.GetInstance().nyDenneUge();
            }
            try
            {
                GemUge SavedJsonClass= await Persistance.LoadGemFromJsonAsync("Uge" + Dato.GetNextUge() + ".json");
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
                List<Arrangement> SavedJsonArrangementer = await Persistance.LoadArrangementFromJsonAsync("Arrangementer.json");
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
