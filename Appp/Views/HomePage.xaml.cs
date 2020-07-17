using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var token = Application.Current.Properties["token"].ToString();
            var name = Application.Current.Properties["name"].ToString();
            var birthday = Application.Current.Properties["birthday"].ToString();
            var phone = Application.Current.Properties["phone"].ToString();
            var email = Application.Current.Properties["email"].ToString();
            Debug.Write(token);
            Debug.Write(name);
            Debug.Write(birthday);
            Debug.Write(phone);
            Debug.Write(email);
        }
    }
}