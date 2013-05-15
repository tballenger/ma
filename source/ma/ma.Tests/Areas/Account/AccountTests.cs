using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ma.Areas.Account.Models;
using MongoDB.Driver;

namespace ma.Tests.Areas.Account
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void SaveAndGetUserProfileTest()
        {
            string username = "Test_" + Guid.NewGuid().ToString();
            string fbid = "123456789";
            string fullname = "Test Molester";
            string link = "http://mylink.com";
            string mobile = "123.123.1313";
            int userid = -999999;

            var ups = new UserProfileService();

            var up = new UserProfile(){
                UserName = username,
                FbUserId = fbid,
                FbUsername = username,
                FullName = fullname,
                Link = link,
                Mobile = mobile,
                UserId = userid,
                Verified = false
            };
            ups.Save(up);

            var result = ups.GetProfileForUsername(username);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.UserName == username);
            Assert.IsTrue(result.FbUserId == fbid);
            Assert.IsTrue(result.FullName == fullname);
            Assert.IsTrue(result.Link == link);
            Assert.IsTrue(result.Mobile == mobile);
            Assert.IsTrue(result.UserId == userid); 
            Assert.IsFalse(result.Verified);

            ups.Remove(result.UserId);
        }

        [TestMethod]
        public void TestDuplicateUserProfileFail()
        {
            string username = "Test_" + Guid.NewGuid().ToString();
            int userid = -999999;

            var ups = new UserProfileService();

            var up = new UserProfile()
            {
                UserName = username,
                UserId = userid,
                Verified = false
            };
            ups.Save(up);

            var up2 = new UserProfile()
            {
                UserName = username,
                UserId = userid,
                Verified = false
            };

            ups.Save(up2);
        }
    }
}
