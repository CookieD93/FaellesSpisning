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
        private int _dropDownValg;
        private readonly ObservableCollection<int> _dropdownHuse;
        public RelayCommand StandardRelayCommand { get; set; }
        public RelayCommand TilmeldRelayCommand { get; set; }
        public Dictionary<int,Bolig> Boligliste { get; set; }
        public ObservableCollection<int> OCmandag { get; set; }
        public ObservableCollection<int> OCtirsdag { get; set; }
        public ObservableCollection<int> OConsdag { get; set; }
        public ObservableCollection<int> OCtorsdag { get; set; }

        private ObservableCollection<int> DropdownHuse
        {
            get { return _dropdownHuse; }
        }

        public int DropDownValg
        {
            get { return _dropDownValg; }
            set { _dropDownValg = value;OnPropertyChanged();GetView(); }
        }


        public TilmeldlingVm()
        {

            // Denne skal loades fra filen hvor boliger er gemt
            Boligliste=new Dictionary<int, Bolig>();
            
            // Denne skal sættes ind et sted hvor den skal køres én gang, og gemmes i en json fil.
            // ==============================================================
            for (int i = 74; i < 97; i++)
            {
                Boligliste.Add(i, new Bolig(i));
            }
            // ==============================================================

            _dropdownHuse = new ObservableCollection<int>(Boligliste.Keys);
            TilmeldRelayCommand = new RelayCommand(Tilmeld);
            StandardRelayCommand = new RelayCommand(SetStandard);

           

            OCmandag = new ObservableCollection<int>();
            OCtirsdag = new ObservableCollection<int>();  
            OConsdag = new ObservableCollection<int>();
            OCtorsdag = new ObservableCollection<int>();        
            
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
            Bolig temp = Boligliste[DropDownValg];
            for (int i = 0; i < 4; i++)
            {
                OCmandag.Add(temp.DaglistMan[i]);
                OCtirsdag.Add(temp.DaglistTir[i]);
                OConsdag.Add(temp.DaglistOns[i]);
                OCtorsdag.Add(temp.DaglistTor[i]);
            }
            

        }
        public void SetStandard()
        {
           Persistance.SaveJson(Boligliste,"Standard.json");
        }

        public void Tilmeld()
        {
           Persistance.SaveJson(Boligliste,"DenneUge.json");

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
