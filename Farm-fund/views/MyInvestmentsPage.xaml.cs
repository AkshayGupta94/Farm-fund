using Farm_fund.ViewModels;

namespace Farm_fund.views;

public partial class MyInvestmentsPage : ContentPage
{
    public MyInvestmentsPage()
    {
        InitializeComponent();
    }

    //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    if (BindingContext is MyInvestmentViewModel viewModel)
    //    {
    //        viewModel.HandleSendMessage(sender, e);
    //        (sender as ListView).SelectedItem = null;  
    //    }
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InvestmentDetailPage());
        //if (BindingContext is MyInvestmentViewModel viewModel)
        //{
        //    viewModel.HandleButtonClick(sender, e);
        //}
    }
}