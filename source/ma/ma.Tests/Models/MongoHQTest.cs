using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System.Configuration;
using MongoDB.Driver;
using ma.Models.Helpers;

namespace ma.Tests.Models
{
    public class TestModelService
    {

        private readonly MongoHelper<TestModel> _testModels;
        public TestModelService()
        {
            _testModels = new MongoHelper<TestModel>();
        }

        public TestModel GetTestModelByFieldName(string fieldName)
        {
            return _testModels.Collection.FindOne(Query.EQ("PropertyField", fieldName));
        }

        public void Save(TestModel tester)
        {
            _testModels.Collection.Save(tester);
        }
    }

    public class TestModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string PropertyField { get; set; }  
    }

    [TestClass]
    public class MongoHQTest
    {
        [TestMethod]
        public void TestConnection()
        {
            var uri = ConfigurationManager.ConnectionStrings["antfarm"].ConnectionString;

            var mongoClient = new MongoClient(uri);
            var db = mongoClient.GetServer().GetDatabase(new MongoUrl(uri).DatabaseName);

            db.GetCollection<TestModel>(typeof(TestModel).Name);
        }

        [TestMethod]
        public void TestModelService_Test()
        {
            var tms = new TestModelService();
            Assert.IsNotNull(tms);
        }

        [TestMethod]
        public void SaveModel_TestModelService_Test()
        {
            var tms = new TestModelService();
            Assert.IsNotNull(tms);

            var fieldProp = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            var tm = new TestModel();
            tm.PropertyField = fieldProp;

            tms.Save(tm);

            var result = tms.GetTestModelByFieldName(fieldProp);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.PropertyField == fieldProp);
        }
    }
}
