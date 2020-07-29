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
using Realms;

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
                    UserRepository ur = new UserRepository();
                    var token = x["data"]["access_token"];
                    var realm = Realm.GetInstance();
                    var name = x["data"]["client"]["name"];
                    var birthday = x["data"]["client"]["birthday"];
                    var phone = x["data"]["client"]["phone"];
                    var email = x["data"]["client"]["email"];
                    Item a = new Item { access_key = token.ToString(),/* name = name.ToString(), birthday = birthday.ToString(), phone = phone.ToString(), email = email.ToString()*/ };
                    ur.Add(a);
                    var tok = realm.All<RealmItem>().ToList();
                    /*                    var combined = string.Join(", ", tok);
                    */
                    Console.WriteLine(tok);



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