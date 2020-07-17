using Appp.Models;
using System;
using Json.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;

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
            entryNumber.Text = "+7 (911) 447-11-83";
            entryPassword.Text = "x5410041";
            entryNumber.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => SignInProcedure(s, e);
        }
        private async void SignInProcedure(object sender, EventArgs e)
        {
            var number = entryNumber.Text;
            var password = entryPassword.Text;
            if (string.IsNullOrEmpty(number) && string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Login", "Login Not Correct", "Ok");
                return;
            }
            using ( var client = new HttpClient())
            {
                var apiLogin = "http://cabinets.itmit-studio.ru/api/login";
                var data = "{\"phone\" : \"" + number + "\", \"password\" : \"" + password + "\"}";

                var contentRequest = new StringContent(data, Encoding.UTF8, "application/json");

                var responce = await client.PostAsync(apiLogin, contentRequest);

                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent content = responce.Content;
                    string jsonString = await content.ReadAsStringAsync();
                    var x = JObject.Parse(jsonString);
                    var token = x["data"]["access_token"];
                    var name = x["data"]["client"]["name"];
                    var birthday = x["data"]["client"]["birthday"];
                    var phone = x["data"]["client"]["phone"];
                    var email = x["data"]["client"]["email"];
                    Application.Current.Properties["token"] = token;
                    Application.Current.Properties["name"] = name;
                    Application.Current.Properties["birthday"] = birthday;
                    Application.Current.Properties["phone"] = phone;
                    Application.Current.Properties["email"] = email;
                    await Application.Current.SavePropertiesAsync();
                    Debug.Write(jsonString);

                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    await DisplayAlert("Login", "Login Failed", "Ok");
                    return;
                }
            }
        }
    }
}