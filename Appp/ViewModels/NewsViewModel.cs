using Appp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Appp
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Posts> postsList { get; set; }
        public ObservableCollection<Posts> PostsList
        {
            get
            {
                return postsList;
            }
            set
            {
                if(value != postsList)
                {
                    postsList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewsViewModel()
        {
            GetDataAsync();
        }
        private async void GetDataAsync()
        {
            var access_token = Application.Current.Properties["token"].ToString();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var result = await client.GetAsync("http://cabinets.itmit-studio.ru/api/news");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(content);
                PostsList = myDeserializedClass.Data;
            }
            /*var jobj = JObject.Parse(content);
            var news = JsonConvert.DeserializeObject<List<Datum>>(jobj["data"].ToString());*/

        }
    }
}
