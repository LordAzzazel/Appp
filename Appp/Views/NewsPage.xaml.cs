using Appp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
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
            BindingContext = new NewsViewModel();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            
            var mydetails = e.Item as Posts;
            await Navigation.PushAsync(new MyListPageDetail(mydetails.head, mydetails.body, mydetails.preview_picture));
        }
        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Constants.backgroundColor;
            }
        }
    }
}