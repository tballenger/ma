using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ma.Models.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ma.Tests.Models
{
	[TestClass]
	public class ProductServiceTest
	{
		[TestMethod]
		public void TestSave()
		{
			ProductService ps = new ProductService();
			var p = new Product()
			{
				SeoTitle = "Test_"+DateTime.Now.ToString(),
				Price = 19.99M,
				WebContent = "Hello World",
				Title = "Test",
				ImageId = "TestImageId",
				Snippit = "Snipppit",
				Tags = new List<string> {"Muscle", "Ant" }
			};

			ps.Save(p);
			var actual = ps.Retrieve(p.SeoTitle);
			Assert.AreEqual(p.SeoTitle, actual.SeoTitle);
		}

		[TestMethod]
		[ExpectedException(typeof (WriteConcernException), "Raise Exception when duplicate seo titles")]
		public void TestDuplicateFailSave()
		{
			ProductService ps = new ProductService();
			var p = new Product()
			{
				SeoTitle = "Test_" + DateTime.Now.ToString(),
				Price = 19.99M,
				WebContent = "Hello World",
				Title = "Test",
				ImageId = "TestImageId",
				Snippit = "Snipppit",
				Tags = new List<string> { "Muscle", "Ant" }
			};
			var q = new Product()
			{
				SeoTitle = "Test_" + DateTime.Now.ToString(),
				Price = 19.99M,
				WebContent = "Hello World",
				Title = "Test",
				ImageId = "TestImageId",
				Snippit = "Snipppit",
				Tags = new List<string> { "Muscle", "Ant" }
			};

			ps.Save(p);
			ps.Save(q);
			var actual = ps.Retrieve(p.SeoTitle);
			Assert.AreEqual(p.SeoTitle, actual.SeoTitle);
		}

	}
}
