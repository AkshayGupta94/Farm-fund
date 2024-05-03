using Farm_fund.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm_fund.ViewModels
{
    public class MarketPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MarketDataModel> _marketData;

        public event PropertyChangedEventHandler PropertyChanged;

        public MarketPageViewModel()
        {
            _marketData = new ObservableCollection<MarketDataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            _marketData.Add(new MarketDataModel()
            {
                Name = "Smith Family Farm Illinois",
                ImageUrl = "https://www.fb.org/imgz/Commodities/SpecialtyCrops/NCFB_MarkStebnicki_LettuceField_feat.jpg"
            });

            _marketData.Add(new MarketDataModel()
            {
                Name = "Cute Potato Idaho",
                ImageUrl = "https://eu-images.contentstack.com/v3/assets/bltdd43779342bd9107/blt85aaaabbcba95bfa/638f395a2fee5b0fa0f05f51/0228F1-1815A-1540x800.jpg"
            });
        }

        public ObservableCollection<MarketDataModel> MarketData
        {
            get { return _marketData; }
            set
            {
                _marketData = value;
            }
        }
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }

        internal void HandleSendMessage(object sender, SelectedItemChangedEventArgs e)
        {
            MarketDataModel marketData = e.SelectedItem as MarketDataModel;
            if (marketData != null)
            {
                //Handle the selected item
            }
        }
        public void HandleButtonClick(object sender, EventArgs e)
        {
            var a = sender as Button;
            var b = a.BindingContext as MarketDataModel;
        }
    }
}
