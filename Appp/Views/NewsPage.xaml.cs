using Appp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            var access_token = Application.Current.Properties["token"].ToString();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var result = await client.GetAsync("http://cabinets.itmit-studio.ru/api/news");
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(access_token);
            Console.WriteLine(content);

        }

    }
}