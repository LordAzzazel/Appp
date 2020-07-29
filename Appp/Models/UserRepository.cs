using AutoMapper;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appp.Models
{
    public class UserRepository
    {
        public void Add(Item user)
        {

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, RealmItem>();
                cfg.CreateMap<RealmItem, Item>();
            });
            var mapper = new Mapper(conf);
            /*var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 1;*/
            using (var realm = Realm.GetInstance())
            {
                var userRealm = mapper.Map<RealmItem>(user);
                using (var transaction = realm.BeginWrite())
                {
                    realm.Add(userRealm, true);
                    transaction.Commit();
                }
            }
        }
    }
}
