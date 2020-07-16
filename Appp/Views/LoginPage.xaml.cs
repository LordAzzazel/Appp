using Appp.Models;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            labelName.TextColor = Constants.mainTextColor;
            labelPassoword.TextColor = Constants.mainTextColor;
            activitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.loginIconHeight;

            entryNumber.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => SignInProcedure(s, e);
        }
        private void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(entryNumber.Text, entryPassword.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password", "OK");
            }
        }

    }
}