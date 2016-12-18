using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Eventmaker.Common;
using Faellesspisning;

namespace Faellesspisning
{
    class TilmeldlingVm : INotifyPropertyChanged
    {
        private int _dropDownValg = 72;
        public RelayCommand StandardRelayCommand { get; set; }
        public RelayCommand TilmeldRelayCommand { get; set; }
        public static ObservableCollection<string> OCmandag { get; set; }
        public static ObservableCollection<string> OCtirsdag { get; set; }
        public static ObservableCollection<string> OConsdag { get; set; }
        public static ObservableCollection<string> OCtorsdag { get; set; }
        public ObservableCollection<int> DropdownHuse { get; set; }
        public int DropDownValg
        {
            get { return _dropDownValg; }
            set
            {
                _dropDownValg = value;
                OnPropertyChanged();
                GetView();
            }
        }
        public TilmeldlingVm()
        {
            DropdownHuse = new ObservableCollection<int>(Singleton.GetInstance().NæsteTempUge.BoligListe.Keys);
            TilmeldRelayCommand = new RelayCommand(Tilmeld);
            StandardRelayCommand = new RelayCommand(SetStandard);
            OCmandag = new ObservableCollection<string>();
            OCtirsdag = new ObservableCollection<string>();
            OConsdag = new ObservableCollection<string>();
            OCtorsdag = new ObservableCollection<string>();
            GetView();
        }
        public void GetView()
        {
            OCmandag.Clear();
            OCtirsdag.Clear();
            OConsdag.Clear();
            OCtorsdag.Clear();
            Bolig temp = Singleton.GetInstance().NæsteTempUge.BoligListe[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                OCmandag.Add(Convert.ToString(temp.DaglistMan[i]));
                OCtirsdag.Add(Convert.ToString(temp.DaglistTir[i]));
                OConsdag.Add(Convert.ToString(temp.DaglistOns[i]));
                OCtorsdag.Add(Convert.ToString(temp.DaglistTor[i]));
            }
         }
        public async void SetStandard()
        {
            await OCTilDagList(Singleton.GetInstance().StandardListe);
            Persistance.SaveJson(Singleton.GetInstance().StandardListe, "Standard.json");
            Tilmeld();
        }
        public async void Tilmeld()
        {
            try
            {
                await OCTilDagList(Singleton.GetInstance().NæsteTempUge.BoligListe);
                GemUge gem = new GemUge();
                gem.importTilGemNæsteUge();
                Persistance.SaveJson(gem, "Uge" + Dato.GetNæsteUge() + ".Json");
                Persistance.MessageDialogHelper.Show("Din Tilmelding er hermed gemt!","Gemt");
            }
            catch (FormatException)
            {
                Persistance.MessageDialogHelper.Show("Der stod tekst i et felt","Fejl");
            }
        }
        public async Task OCTilDagList(Dictionary<int,Bolig> hvilkenBoligListe)
        {
            Bolig tempBolig = hvilkenBoligListe[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                #region If WhiteSpace
                if (OCmandag[i] == "")
                {
                    OCmandag[i] = "0";
                }
                if (OCtirsdag[i] == "")
                {
                    OCtirsdag[i] = "0";
                }
                if (OConsdag[i] == "")
                {
                    OConsdag[i] = "0";
                }
                if (OCtorsdag[i] == "")
                {
                    OCtorsdag[i] = "0";
                } 
                #endregion
                tempBolig.DaglistMan[i] = int.Parse(OCmandag[i]);
                tempBolig.DaglistTir[i] = int.Parse(OCtirsdag[i]);
                tempBolig.DaglistOns[i] = int.Parse(OConsdag[i]);
                tempBolig.DaglistTor[i] = int.Parse(OCtorsdag[i]);
            }
            hvilkenBoligListe[DropDownValg] = tempBolig;
            await Task.Delay(500); // Nødvendigt Delay (ellers får den ikke gemt de rigtige ting)
        }
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
    }
}
