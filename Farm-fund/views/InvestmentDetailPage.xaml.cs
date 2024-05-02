using System.Collections.ObjectModel;

namespace Farm_fund.views;

public partial class InvestmentDetailPage : ContentPage
{
    public ObservableCollection<InvestmentGraphModel> InvestmentChartData { get; set; }

    public InvestmentDetailPage()
	{
		InitializeComponent();
        InvestmentChartData = new ObservableCollection<InvestmentGraphModel>
        {
            new InvestmentGraphModel { Month = new DateTime(2021, 1, 1), Value = 100 },
            new InvestmentGraphModel { Month = new DateTime(2021, 2, 1), Value = 150 },
            new InvestmentGraphModel { Month = new DateTime(2021, 3, 1), Value = 130 },
            new InvestmentGraphModel { Month = new DateTime(2021, 4, 1), Value = 170 },
        };
        this.BindingContext = this;
    }

    public class InvestmentGraphModel
    {
        public DateTime Month { get; set; }
        public double Value { get; set; }
    }
}