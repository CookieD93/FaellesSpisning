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
        private string _payment ;
        public Dictionary<int, Bolig> Boligliste { get; set; }
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
            Boligliste = new Dictionary<int, Bolig>();
            Boligliste = Singleton.GetInstance().DenneTempUge.BoligListe;
            betal = new Betaling();
        }
        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
