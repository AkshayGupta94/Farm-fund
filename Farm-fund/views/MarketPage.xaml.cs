using Farm_fund.ViewModels;

namespace Farm_fund.views;

public partial class MarketPage : ContentPage
{
	public MarketPage()
	{
		InitializeComponent();
	}

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (BindingContext is MarketPageViewModel viewModel)
		{
            viewModel.HandleSendMessage(sender, e);
        }

    }
}