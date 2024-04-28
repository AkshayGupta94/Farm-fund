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
    public class FarmListPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FarmDataModel> _farmData;

        public event PropertyChangedEventHandler PropertyChanged;

        public FarmListPageViewModel()
        {
            _farmData = new ObservableCollection<FarmDataModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            _farmData.Add(new FarmDataModel()
            {
                Name = "Farm 1",
                Details = "Farm Is infected with pest.",
                ImageUrl = "https://thumbs.dreamstime.com/b/country-farm-landscape-25598352.jpg"
            });

            _farmData.Add(new FarmDataModel()
            {
                Name = "Farm 2",
                Details = "Weed growth is visible in farm",
                ImageUrl = "https://www.libertyhillfarm.com/wp-content/uploads/2021/06/lhf-homepage-002.jpg"
            });

            _farmData.Add(new FarmDataModel()
            {
                Name = "Farm 3",
                Details = "Crops are growing as predicted",
                ImageUrl = "https://www.shutterstock.com/image-photo/germany-bavaria-vast-barley-field-600nw-2245723651.jpg"
            });
        }

        public ObservableCollection<FarmDataModel> FarmData
        {
            get { return _farmData; }
            set
            {
                _farmData = value;
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
            FarmDataModel investment = e.SelectedItem as FarmDataModel;
            if (investment != null)
            {
                //Handle the selected item
            }
        }
    }
}
