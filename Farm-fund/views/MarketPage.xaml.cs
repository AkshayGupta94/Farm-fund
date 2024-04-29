using Farm_fund.ViewModels;

namespace Farm_fund.views;

public partial class MarketPage : ContentPage
{
	public MarketPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MarketDetailPage());
        //if (BindingContext is MarketPageViewModel viewModel)
        //{
        //    viewModel.HandleButtonClick(sender, e);
        //}
    }
}