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
        public string Payment
        {
            get { return _payment; }
            set { _payment = value; OnPropertyChanged(); }
        }

        public Betaling betal { get; set; }

        private int _dropDownValg;
        private readonly ObservableCollection<int> _dropdownHuse;
        private string _payment ;


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
                _dropDownValg = value; getFuckingPayment(); OnPropertyChanged();

            }
        }
        public void getFuckingPayment()
        {
            Payment = betal.HusBetaling(_dropDownValg);
        }
        


        public HistorikVM()
        {
            // Denne skal loades fra filen hvor boliger er gemt
            Boligliste = new Dictionary<int, Bolig>();

            // Denne skal sættes ind et sted hvor den skal køres én gang, og gemmes i en json fil.
            // ==============================================================
            //for (int i = 74; i < 97; i++)
            //{
            //    Boligliste.Add(i, new Bolig(i));
            //}
            // ==============================================================

            _dropdownHuse = new ObservableCollection<int>(Boligliste.Keys);
            Boligliste = Singleton.GetInstance().DenneTempUge.BoligListe;
            betal = new Betaling();
            
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
