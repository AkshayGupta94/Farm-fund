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
                Name = "Farm 1",
                Details = "Sugar Cane farm available for investment",
                ImageUrl = "https://thumbs.dreamstime.com/b/country-farm-landscape-25598352.jpg"
            });

            _marketData.Add(new MarketDataModel()
            {
                Name = "Farm 2",
                Details = "Potato farm available for investment",
                ImageUrl = "https://www.libertyhillfarm.com/wp-content/uploads/2021/06/lhf-homepage-002.jpg"
            });

            _marketData.Add(new MarketDataModel()
            {
                Name = "Farm 3",
                Details = "Wheat farm available for investment",
                ImageUrl = "https://www.shutterstock.com/image-photo/germany-bavaria-vast-barley-field-600nw-2245723651.jpg"
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
    }
}
