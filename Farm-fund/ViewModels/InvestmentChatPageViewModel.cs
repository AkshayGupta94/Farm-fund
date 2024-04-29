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
    public class InvestmentChatPageViewModel : INotifyPropertyChanged
    {
        public InvestmentChatPageViewModel()
        {
            _currentUser = new Author() { Name = "Margaret"};
            _messages = new ObservableCollection<object>();
            GenerateMessages();
        }

        private ObservableCollection<object> _messages;

        private Author _currentUser;
        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<object> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
            }
        }

        public Author CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }

        public void HandleSendMessage(object sender, Syncfusion.Maui.Chat.SendMessageEventArgs e)
        {
            this._messages.Add(new TextMessage()
            {
                Author = CurrentUser,
                Text = e.Message?.Text,
            });
        }



        private void GenerateMessages()
        {
            this._messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Text = "Hello, I am Field Mate, how can I help you today?",
            });

            this._messages.Add(new TextMessage()
            {
                Author = CurrentUser,
                Text = "How is my investment in farm 1 going?",
            });

            this._messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Text = "The farm 1 yeild is very impressive, you can expect good returns in 2 months. Here is the most recent picture of your farm",
            });
            this._messages.Add(new ImageMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Source = "farm.jpg",
            });
        }
    }

}
