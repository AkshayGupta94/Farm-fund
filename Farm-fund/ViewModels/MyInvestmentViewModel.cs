using Farm_fund.DataModels;
using Syncfusion.Maui.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm_fund.ViewModels
{
    public class MyInvestmentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<InvestmentModel> _investmentData;

        public event PropertyChangedEventHandler PropertyChanged;

        public MyInvestmentViewModel()
        {
            _investmentData = new ObservableCollection<InvestmentModel>();
            GenerateData();
        }

        private void GenerateData()
        {
            _investmentData.Add(new InvestmentModel()
            {
                Name = "Farm 1",
                Cost = "$100,000",
                Details = "Growth is progressing as expected",
                ImageUrl = "https://thumbs.dreamstime.com/b/country-farm-landscape-25598352.jpg"
            });

            _investmentData.Add(new InvestmentModel()
            {
                Name = "Farm 2",
                Cost = "$200,000",
                Details = "Bumper yield is expected",
                ImageUrl = "https://www.libertyhillfarm.com/wp-content/uploads/2021/06/lhf-homepage-002.jpg"
            });

            _investmentData.Add(new InvestmentModel()
            {
                Name = "Farm 3",
                Cost = "$300,000",
                Details = "Farm is going through pest attack",
                ImageUrl = "https://www.shutterstock.com/image-photo/germany-bavaria-vast-barley-field-600nw-2245723651.jpg"
            });
        }

        public ObservableCollection<InvestmentModel> InvestmentData
        {
            get { return _investmentData; }
            set
            {
                _investmentData = value;
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
           InvestmentModel investment = e.SelectedItem as InvestmentModel;
            if (investment != null)
            {
                //Handle the selected item
            }
        }
        public void HandleButtonClick(object sender, EventArgs e)
        {
            var a = sender as Button;
            var b = a.BindingContext as InvestmentModel;
        }
    }
}
