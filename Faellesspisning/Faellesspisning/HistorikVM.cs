using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Faellesspisning.Annotations;

namespace Faellesspisning
{
    class HistorikVM : INotifyPropertyChanged
    {
        private int _dropDownValg;
        private readonly ObservableCollection<int> _dropdownHuse;
        private int _husNr;
        public Dictionary<int, Bolig> Boligliste { get; set; }
        private ObservableCollection<int> DropdownHuse
        {
            get { return _dropdownHuse; }
        }
        public int DropDownValg
        {
            get { return _dropDownValg; }
            set
            {
                _dropDownValg = value; OnPropertyChanged();

            }
        }

        public int HusNr1
        {
            get { return _husNr; }
            set { _husNr = value; OnPropertyChanged();}
        }

        public HistorikVM()
        {
            // Denne skal loades fra filen hvor boliger er gemt
            Boligliste = new Dictionary<int, Bolig>();

            // Denne skal sættes ind et sted hvor den skal køres én gang, og gemmes i en json fil.
            // ==============================================================
            for (int i = 74; i < 97; i++)
            {
                Boligliste.Add(i, new Bolig(i));
            }
            // ==============================================================

            _dropdownHuse = new ObservableCollection<int>(Boligliste.Keys);
            HusNr1 = 0;
        }

        
        
        #region MyRegion




        


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
