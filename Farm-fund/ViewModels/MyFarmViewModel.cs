using Syncfusion.Maui.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Farm_fund.ViewModels
{
    public class MyFarmViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> _messages;

        private Author _currentUser;
        public event PropertyChangedEventHandler PropertyChanged;

        public MyFarmViewModel()
        {
            _currentUser = new Author() { Name = "Margaret"};
            _messages = new ObservableCollection<object>();
            GenerateMessages();
        }   

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
                Author = _currentUser,
                Text = "How is my farm yield?",
            });

            this._messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Text = "The farm yeild is very impressive, you can expect good output. Here is the most recent picture of your farm",
            });
            this._messages.Add(new ImageMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Source = "https://www.timeforkids.com/wp-content/uploads/2019/02/190222015997.jpg",
            });
        }

       
    }
}
