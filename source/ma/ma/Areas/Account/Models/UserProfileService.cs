using ma.Models.Helpers;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ma.Areas.Account.Models
{
    public class UserProfileService
    {

        private readonly MongoHelper<UserProfile> _profiles;

        //MongoDatabase mongoDB = MongoServer.Create("mongodb://localhost").GetDatabase("devnull_aspnetdb");
        //mongoDB.GetCollection<UserProfile>("UserProfile")
        public UserProfileService()
        {
            _profiles = new MongoHelper<UserProfile>();
        }

        //var userProfile = collection.FindOne(Query.EQ("UserName", model.UserName));
        public UserProfile GetProfileForUsername(string username)
        {
            return _profiles.Collection.FindOne(Query.EQ("UserName", username));
        }
        
        public UserProfile GetProfileForUserId(int userId)
        {
            return _profiles.Collection.FindOne(Query.EQ("_id", userId));
        }

        // collection.Save<UserProfile>(userProfile, WriteConcern.Acknowledged);
        public void Save(UserProfile profile)
        {
            _profiles.Collection.Save(profile);
        }
    }
}
