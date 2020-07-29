using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Appp.Models
{
    public class Constants
    {
        public static bool IsDev = true;

        public static Color backgroundColor = Color.FromRgb(58, 153, 215);
        public static Color mainTextColor = Color.White;


        public static int loginIconHeight = 120;

        public static string AuthUrl = "mandatory-granite-shirt.us1a.cloud.realm.io"; // <- update this
        public static string RealmPath = "ToDo";
    }
}
