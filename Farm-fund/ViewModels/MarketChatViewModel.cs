using Newtonsoft.Json.Linq;
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
    public class MarketChatViewModel
    {
        int count = 0;
        public MarketChatViewModel()
        {
            _currentUser = new Author() { Name = "Srishti" };
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

        public async void HandleSendMessage(object sender, Syncfusion.Maui.Chat.SendMessageEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(100);
            //this._messages.Add(new TextMessage()
            //{
            //    Author = CurrentUser,
            //    Text = e.Message?.Text,
            //});
            if (count == 0)
            {

                string reply = await httpClient.GetStringAsync(@"https://farm-python.azurewebsites.net/api/marketChat1?clientId=-Y9czaDvd7R4HY-Am_rUSrWZwh-7NmCQH9GSMWT16_wvAzFuz86wtQ==");
                JObject jsonResponse = JObject.Parse(reply);

                // Access the message field (string)
                string message = jsonResponse["message"].ToString();

                // Access the image field (list of strings)
                JArray imagesArray = (JArray)jsonResponse["images"];
                string[] images = imagesArray.ToObject<string[]>();
                this._messages.Add(new TextMessage()
                {
                    Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                    Text = message,
                });
                foreach (var img in images)
                {
                    this._messages.Add(new ImageMessage()
                    {
                        Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                        Source = img
                    });
                }
                count++;
            }
            else if (count == 1)
            {
                string reply = await httpClient.GetStringAsync(@"https://farm-python.azurewebsites.net/api/marketChat2?clientId=ymtoOlGYwSQDNek_r_5QTt0y0wguWTut1gWIN4ntb7RNAzFuQqCe6w==");
                JObject jsonResponse = JObject.Parse(reply);

                // Access the message field (string)
                string message = jsonResponse["message"].ToString();

                // Access the image field (list of strings)
                JArray imagesArray = (JArray)jsonResponse["images"];
                string[] images = imagesArray.ToObject<string[]>();
                this._messages.Add(new TextMessage()
                {
                    Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                    Text = message,
                });
                foreach (var img in images)
                {
                    this._messages.Add(new ImageMessage()
                    {
                        Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                        Source = img
                    });
                }
                count++;
            }
        }



        private void GenerateMessages()
        {
            this._messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Text = "Hello, I am Field Mate, how can I help you today?",
            });

            //this._messages.Add(new TextMessage()
            //{
            //    Author = CurrentUser,
            //    Text = "Should i invest in wheat farm?",
            //});

            //this._messages.Add(new TextMessage()
            //{
            //    Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
            //    Text = "The wheat yield is expected to be above average this year. You should invest it. This is a yield from last year",
            //});
            //this._messages.Add(new ImageMessage()
            //{
            //    Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
            //    Source = "farm.jpg",
            //});
        }

    }
}
