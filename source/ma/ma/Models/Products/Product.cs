using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace ma.Models.Products
{

	public class Product
	{
		[BsonId]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string SeoTitle { get; set; }
		public List<string> Tags { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public string Snippit { get; set; }
		public decimal Price { get; set; }
		public string ImageId { get; set; }
		public DateTime Expires { get; set; }
		public string WebContent { get; set; }
	}
}