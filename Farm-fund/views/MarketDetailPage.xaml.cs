using System.Collections.ObjectModel;

namespace Farm_fund.views;

public partial class MarketDetailPage : ContentPage
{
    public ObservableCollection<MarketGraphModel> ChartData { get; set; }

    public MarketDetailPage()
	{
        InitializeComponent();
        ChartData = new ObservableCollection<MarketGraphModel>
        {
            new MarketGraphModel { Year = new DateTime(2018, 1, 1), Value = 100 },
            new MarketGraphModel { Year = new DateTime(2019, 1, 1), Value = 150 },
            new MarketGraphModel { Year = new DateTime(2020, 1, 1), Value = 130 },
            new MarketGraphModel { Year = new DateTime(2021, 1, 1), Value = 170 },
        };
        this.BindingContext = this;
    }
}

public class MarketGraphModel
{
    public DateTime Year { get; set; }
    public double Value { get; set; }
}