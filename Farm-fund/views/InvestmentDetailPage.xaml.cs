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
            new InvestmentGraphModel { Month = new DateTime(2024, 1, 1), Value = 5 },
            new InvestmentGraphModel { Month = new DateTime(2024, 2, 1), Value = 8 },
            new InvestmentGraphModel { Month = new DateTime(2024, 3, 1), Value = 15 },
            new InvestmentGraphModel { Month = new DateTime(2024, 4, 1), Value = 25 },            
        };
        this.BindingContext = this;
    }

    public class InvestmentGraphModel
    {
        public DateTime Month { get; set; }
        public double Value { get; set; }
    }
}