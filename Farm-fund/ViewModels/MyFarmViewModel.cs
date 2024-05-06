using Newtonsoft.Json.Linq;
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
        int count = 0;
        public MyFarmViewModel()
        {
            _currentUser = new Author() { Name = "Srishti"};
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

                string reply = await httpClient.GetStringAsync(@"https://farm-python.azurewebsites.net/api/farmChat1?clientId=qM_zmGnzBCGMZLj7rgWydMiXbNFm6dHieq7_K5fkk6ldAzFuXoaTCw==");
                this._messages.Add(new TextMessage()
                {
                    Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                    Text = reply,
                });
                count++;
            }
            else if (count == 1)
            {
                string reply = await httpClient.GetStringAsync(@"https://farm-python.azurewebsites.net/api/farmChat2?clientId=9UL7LoqC-uy_DalbtB-QgPSjLzsEceAU5ZJZszZf7z8DAzFuut6z4Q==");
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
            else
            {
                string reply = await httpClient.GetStringAsync(@"https://farm-python.azurewebsites.net/api/farmChat3?clientId=DQzZ7G32bBFUxjev8ErM-zDcpFz_HiCt5jxbfq5iDcNwAzFuh_olmg==");
                JObject jsonResponse = JObject.Parse(reply);


                string message = jsonResponse["message"].ToString();


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
            }
        }



        private void GenerateMessages()
        {
            this._messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Field Mate", Avatar = "farmfund_bot.png" },
                Text = "Hello, I am Field Mate, how can I help you today?",
            });

        }

       
    }
}
