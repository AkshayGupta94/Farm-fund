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
                ImageUrl = "https://thumbs.dreamstime.com/b/country-farm-landscape-25598352.jpg"
            });

            _marketData.Add(new MarketDataModel()
            {
                Name = "Cute Potato Idaho",
                ImageUrl = "https://www.libertyhillfarm.com/wp-content/uploads/2021/06/lhf-homepage-002.jpg"
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
