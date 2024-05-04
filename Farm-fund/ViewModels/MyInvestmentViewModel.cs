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
                Name = "Wills Wheat Farm Kansas",
                Cost = "$100,000",
                Details = "The farm yield is on track with our projections",
                ImageUrl = "https://t3.ftcdn.net/jpg/06/78/40/56/360_F_678405631_4HnZqPCkL0C7g7thhp3GMJALIwAMmVMi.jpg"
            });
            _investmentData.Add(new InvestmentModel()
            {
                Name = "Happy Farms Pennsylvania",
                Cost = "$50,000",
                Details = "Farm got affected from pest last season, which reduced the yield by 30%.",
                ImageUrl = "https://thumbs.dreamstime.com/b/country-farm-landscape-25598352.jpg"
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
