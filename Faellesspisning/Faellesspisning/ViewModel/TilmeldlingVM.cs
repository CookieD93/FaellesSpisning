using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Common;

namespace Faellesspisning
{
    class TilmeldlingVm : INotifyPropertyChanged
    {
       // private Dictionary<int, Bolig> tempListe;
        private int _dropDownValg=72;
       // private readonly ObservableCollection<int> _dropdownHuse;
        public RelayCommand StandardRelayCommand { get; set; }
        public RelayCommand TilmeldRelayCommand { get; set; }
        //public Dictionary<int,Bolig> Boligliste { get; set; }
        public ObservableCollection<string> OCmandag { get; set; }
        public ObservableCollection<string> OCtirsdag { get; set; }
        public ObservableCollection<string> OConsdag { get; set; }
        public ObservableCollection<string> OCtorsdag { get; set; }

        public ObservableCollection<int> DropdownHuse { get; set; }
        //{
        //    get { return _dropdownHuse; }
        //}

        public int DropDownValg
        {
            get { return _dropDownValg; }
            set { _dropDownValg = value;OnPropertyChanged();GetView(); }
        }

        
        public TilmeldlingVm()
        {
            DropdownHuse = new ObservableCollection<int>(Singleton.GetInstance().NæsteTempUge.BoligListe.Keys);
            TilmeldRelayCommand = new RelayCommand(Tilmeld);
            StandardRelayCommand = new RelayCommand(SetStandard);
            //tempListe = new Dictionary<int,Bolig>();
            //for (int i = 0; i < 22; i++)
            //{
            //    tempListe.Add(i,new Bolig(i));
            //}
            //Persistance.SaveJson(tempListe,"templiste.json");
                
            OCmandag = new ObservableCollection<string>();
            OCtirsdag = new ObservableCollection<string>();  
            OConsdag = new ObservableCollection<string>();
            OCtorsdag = new ObservableCollection<string>();        
            GetView();
            // foreach list in lists
            // udfold dagene
            // foreach dag i dagene
            // udfold v/b/b/b
            
        }

        public void GetView()
        {

            //Convert from int to string

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
        //SetStandard skal vidst ændres lidt, da den gemmer hele den 
        public async void SetStandard() 
        {
           await OCTilDagList(Singleton.GetInstance().StandardListe);
           Persistance.SaveJson(Singleton.GetInstance().StandardListe,"Standard.json");
           Tilmeld();
        }

        public async void Tilmeld()
        {
            await OCTilDagList(Singleton.GetInstance().NæsteTempUge.BoligListe);
            GemUge gem = new GemUge();
            gem.importTilGemNæsteUge();
            Persistance.SaveJson(gem,"Uge"+Dato.GetNextUge()+".Json");
            Persistance.MessageDialogHelper.Show("Du er nu Tilmeldt", "Tilmeldt");

        }

        public async Task OCTilDagList(Dictionary<int,Bolig> hvilkenBoligListe)
        {
            Bolig tempBolig = hvilkenBoligListe[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
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
