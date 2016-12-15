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
            DropdownHuse = new ObservableCollection<int>(Singleton.GetInstance().Boligliste.Keys);
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
            Bolig temp = Singleton.GetInstance().Boligliste[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                OCmandag.Add(Convert.ToString(temp.DaglistMan[i]));
                OCtirsdag.Add(Convert.ToString(temp.DaglistTir[i]));
                OConsdag.Add(Convert.ToString(temp.DaglistOns[i]));
                OCtorsdag.Add(Convert.ToString(temp.DaglistTor[i]));
            }
            

        }
        //Indtil videre bliver OC's ikke ændret når man ændrer i appen.
        //fejl fundet, OC's er ints og textboxes i UI prøver at gemme som string. <--- need work around
        public async void SetStandard() 
        {
           // OCmandag[0] = "1534"; //Test ændring, kan slettes når UI'et opdaterer collections.
            
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
            Persistance.MessageDialogHelper.Show("Din tilmelding er Gemt", "Gemt");

        }

        public async Task OCTilDagList()
        {
            Bolig standTemp = Singleton.GetInstance().Boligliste[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                standTemp.DaglistMan[i] = int.Parse(OCmandag[i]);
                standTemp.DaglistTir[i] = int.Parse(OCtirsdag[i]);
                standTemp.DaglistOns[i] = int.Parse(OConsdag[i]);
                standTemp.DaglistTor[i] = int.Parse(OCtorsdag[i]);
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
