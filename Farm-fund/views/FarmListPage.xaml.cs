using Farm_fund.ViewModels;

namespace Farm_fund.views;

public partial class FarmListPage : ContentPage
{
	public FarmListPage()
	{
		InitializeComponent();
	}

    //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    if (BindingContext is FarmListPageViewModel viewModel)
    //    {
    //        viewModel.HandleSendMessage(sender, e);
    //        (sender as ListView).SelectedItem = null;
    //    }
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FarmDetailPage());
        //if (BindingContext is FarmListPageViewModel viewModel)
        //{
        //    viewModel.HandleButtonClick(sender, e);
        //}
    }
}