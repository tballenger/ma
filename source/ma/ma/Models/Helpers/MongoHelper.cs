using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ma.Models.Helpers
{
    public class MongoHelper
    {
        public MongoDatabase DB { get; set; }

        public MongoHelper()
        {
            var uri = ConfigurationManager.ConnectionStrings["antfarm"].ConnectionString;

            var mongoClient = new MongoClient(uri);
            DB = mongoClient.GetServer().GetDatabase(new MongoUrl(uri).DatabaseName);
        }
    }

    public class MongoHelper<T> : MongoHelper where T : class
    {
        public MongoCollection<T> Collection { get; private set; }

        public MongoHelper() : base()
        {
            Collection = DB.GetCollection<T>(typeof(T).Name); //Maybe ToLower?
        }
    }
}