using Appp.ViewModels;
using System;

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
            Init();
            BindingContext = new HomePageViewModel();

        }

        private void Init() {
            /*var name = Application.Current.Properties["name"].ToString();
            var birthday = Application.Current.Properties["birthday"].ToString();
            var phone = Application.Current.Properties["phone"].ToString();
            var email = Application.Current.Properties["email"].ToString();
            Name.Text += name;
            Birthday.Text += birthday;
            Phone.Text += phone;
            Email.Text += email;*/
        }

    }
}