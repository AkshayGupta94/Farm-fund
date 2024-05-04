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
                Name = "Grow Farms Iowa",
                ImageUrl = "https://www.libertyhillfarm.com/wp-content/uploads/2021/06/lhf-homepage-002.jpg"
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

        internal void HandleSendMessage(object sender, SelectionChangedEventArgs e)
        {
            FarmDataModel investment = e.CurrentSelection as FarmDataModel;
            if (investment != null)
            {
                //Handle the selected item
            }
        }
        public void HandleButtonClick(object sender, EventArgs e)
        {
            var a = sender as Button;
            var b = a.BindingContext as FarmDataModel;
        }
    }
}
