using Appp.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appp.ViewModels
{
    public class HomePageViewModel
    {
        private readonly Realm realm;
        public IEnumerable<RealmItem> Items { get; }

        public HomePageViewModel()
        {
            realm = Realm.GetInstance();
            Items = realm.All<RealmItem>().ToList();
        }
    }
}
