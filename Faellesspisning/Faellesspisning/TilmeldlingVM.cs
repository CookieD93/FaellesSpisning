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
            Bolig hus1 = new Bolig(74);
            hus1.Standard[0, 0] = 0;
            hus1.Standard[0, 1] = 0;
            hus1.Standard[0, 2] = 0;
            hus1.Standard[0, 3] = 0;
            hus1.Standard[1, 0] = 0;
            hus1.Standard[1, 1] = 0;
            hus1.Standard[1, 2] = 0;
            hus1.Standard[1, 3] = 0;
            hus1.Standard[2, 0] = 0;
            hus1.Standard[2, 1] = 0;
            hus1.Standard[2, 2] = 0;
            hus1.Standard[2, 3] = 0;
            hus1.Standard[3, 0] = 0;
            hus1.Standard[3, 1] = 0;
            hus1.Standard[3, 2] = 0;
            hus1.Standard[3, 3] = 0;
            Boligliste.Add(74,new Bolig(74));
            

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
