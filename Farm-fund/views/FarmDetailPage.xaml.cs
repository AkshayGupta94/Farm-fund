namespace Farm_fund.views;

public partial class FarmDetailPage : ContentPage
{
	public FarmDetailPage()
	{
        InitializeComponent();
	}

    private void farmDetailPageChat_SendMessage(object sender, Syncfusion.Maui.Chat.SendMessageEventArgs e)
    {
        //if (BindingContext is MyFarmViewModel viewModel)
        //{

        //    viewModel.HandleSendMessage(sender, e);
        //}
    }

    private async void farmDetailPageChat_AttachmentButtonClickedAsync(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select farm photo"
        });
    }
}