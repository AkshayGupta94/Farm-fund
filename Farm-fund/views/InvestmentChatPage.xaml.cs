using Farm_fund.ViewModels;

namespace Farm_fund.views;

public partial class InvestmentChatPage : ContentPage
{
	public InvestmentChatPage()
	{
		InitializeComponent();
	}

    private void farmPageChat_SendMessage(object sender, Syncfusion.Maui.Chat.SendMessageEventArgs e)
    {
        if (BindingContext is InvestmentChatPageViewModel viewModel)
        {
            viewModel.HandleSendMessage(sender, e);
        }
    }

    private async void farmPageChat_AttachmentButtonClicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select farm photo"
        });
    }
}