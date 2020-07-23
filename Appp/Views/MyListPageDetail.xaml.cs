using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPageDetail : ContentPage
    {
        public MyListPageDetail(string Name, string Body, string Image)
        {
            InitializeComponent();
            MyItemNameShow.Text = Name;
            MyBody.Text = Body;
            MyImage.Source = new UriImageSource()
            {
                Uri = new Uri("http://cabinets.itmit-studio.ru/" + Image)
            };
        }

    }
}