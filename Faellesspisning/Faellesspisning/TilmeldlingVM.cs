using System;
using System.Collections.Generic;
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
        public RelayCommand StandardRelayCommand { get; set; }
        public RelayCommand TilmeldRelayCommand { get; set; }
        public Dictionary<int,Bolig> Boligliste { get; set; }

        public int DropDownValg
        {
            get { return _dropDownValg; }
            set { _dropDownValg = value;OnPropertyChanged();GetView(); }
        }


        public TilmeldlingVm()
        {
            StandardRelayCommand = new RelayCommand(SetStandard);
            TilmeldRelayCommand = new RelayCommand(Tilmeld);


        }

        public void GetView()
        {
            
        }
        public void SetStandard()
        {
           // HusSamling.GetHusSamling().HuseOC.Add(new Bolig(72));
            
            Persistance.SaveJson(HusSamling.GetHusSamling().HuseOC,"Standard.json");
        }

        public void Tilmeld()
        {
            
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
