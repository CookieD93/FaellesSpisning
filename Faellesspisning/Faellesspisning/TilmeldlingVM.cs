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
        public ObservableCollection<int> OCmandag { get; set; }
        public ObservableCollection<int> OCtirsdag { get; set; }
        public ObservableCollection<int> OConsdag { get; set; }
        public ObservableCollection<int> OCtorsdag { get; set; }

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

            // Denne skal loades fra filen hvor boliger er gemt
            //Boligliste=new Dictionary<int, Bolig>();
            
            // Denne skal sættes ind et sted hvor den skal køres én gang, og gemmes i en json fil.
            // ==============================================================
            //for (int i = 74; i < 97; i++)
            //{
            //    Singleton.GetInstance().Boligliste.Add(i, new Bolig(i));
            //}
            // ==============================================================

            DropdownHuse = new ObservableCollection<int>(Singleton.GetInstance().Boligliste.Keys);
            TilmeldRelayCommand = new RelayCommand(Tilmeld);
            StandardRelayCommand = new RelayCommand(SetStandard);
            //tempListe = new Dictionary<int,Bolig>();
            //for (int i = 0; i < 22; i++)
            //{
            //    tempListe.Add(i,new Bolig(i));
            //}
            //Persistance.SaveJson(tempListe,"templiste.json");
                
            OCmandag = new ObservableCollection<int>();
            OCtirsdag = new ObservableCollection<int>();  
            OConsdag = new ObservableCollection<int>();
            OCtorsdag = new ObservableCollection<int>();        
            GetView();
            // foreach list in lists
            // udfold dagene
            // foreach dag i dagene
            // udfold v/b/b/b
            
        }

        public void GetView()
        {

            OCmandag.Clear();
            OCtirsdag.Clear();
            OConsdag.Clear();
            OCtorsdag.Clear();
            Bolig temp = Singleton.GetInstance().Boligliste[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                OCmandag.Add(temp.DaglistMan[i]);
                OCtirsdag.Add(temp.DaglistTir[i]);
                OConsdag.Add(temp.DaglistOns[i]);
                OCtorsdag.Add(temp.DaglistTor[i]);
            }
            

        }
        //Indtil videre bliver OC's ikke ændret når man ændrer i appen.
        //fejl fundet, OC's er ints og textboxes i UI prøver at gemme som string. <--- need work around
        public async void SetStandard() 
        {
            OCmandag[0] = 1534; //Test ændring, kan slettes når UI'et opdaterer collections.
            
           await OCTilDagList();
           Persistance.SaveJson(Singleton.GetInstance().Boligliste,"Standard.json");
            Tilmeld();
        }

        public async void Tilmeld()
        {
            await OCTilDagList();
            Gem gem = new Gem();
            gem.importTilGem();
           Persistance.SaveJson(gem,"Uge"+Dato.GetDenneUge()+".Json");

        }

        public async Task OCTilDagList()
        {
            Bolig standTemp = Singleton.GetInstance().Boligliste[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                standTemp.DaglistMan[i] = OCmandag[i];
                standTemp.DaglistTir[i] = OCtirsdag[i];
                standTemp.DaglistOns[i] = OConsdag[i];
                standTemp.DaglistTor[i] = OCtorsdag[i];
            }
            Singleton.GetInstance().Boligliste[DropDownValg] = standTemp;
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
