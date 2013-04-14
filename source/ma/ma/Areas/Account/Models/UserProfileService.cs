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

        public UserProfileService()
        {
            _profiles = new MongoHelper<UserProfile>();
        }

        public UserProfile GetProfileForUsername(string username)
        {
            return _profiles.Collection.FindOne(Query.EQ("UserName", username));
        }
        
        public UserProfile GetProfileForUserId(int userId)
        {
            return _profiles.Collection.FindOne(Query.EQ("_id", userId));
        }

        public void Save(UserProfile profile)
        {
            _profiles.Collection.Save(profile);
        }

        public void Remove(int id)
        {
            _profiles.Collection.Remove(Query.EQ("_id", id));
        }
    }
}
