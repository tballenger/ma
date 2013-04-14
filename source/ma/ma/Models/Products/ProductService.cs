using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ma.Mongo;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ma.Models.Products
{
	public class ProductService
	{
		private readonly MongoHelper<Product> _models;
		public ProductService()
		{
			_models = new MongoHelper<Product>();
			_models.Collection.EnsureIndex(new IndexKeysBuilder().Ascending("SeoTitle"), IndexOptions.SetUnique(true));
		}
		public bool Save(Product p)
		{

			p.Created = DateTime.Now;
			p.Updated = DateTime.Now;

			var result = _models.Collection.Save<Product>(p,SafeMode.True);

			return result.Ok;
		}

		public Product Retrieve(string seoTitle)
		{
			if (seoTitle == null)
			{
				throw new ArgumentNullException("seoTitle");
			}
			var query = Query.EQ("SeoTitle", seoTitle);
			return _models.Collection.FindOneAs<Product>(query);
		}
	}
}