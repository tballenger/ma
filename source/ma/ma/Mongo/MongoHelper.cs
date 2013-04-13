using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace ma.Mongo
{
    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }

        public MongoHelper()
        {
            var uri = ConfigurationManager.ConnectionStrings["antfarm"].ConnectionString;

            var mongoClient = new MongoClient(uri);
            var db = mongoClient.GetServer().GetDatabase(new MongoUrl(uri).DatabaseName);

            Collection = db.GetCollection<T>(typeof(T).Name); //Maybe ToLower?
        }
    }
}