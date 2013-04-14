﻿using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ma.Models
{
    public class IntIdGenerator : IIdGenerator
    {
        public object GenerateId(object container, object document)
        {
            var idSequenceCollection = ((MongoCollection)container).Database.GetCollection("IDSequence");

            var query = Query.EQ("_id", ((MongoCollection)container).Name);

            return idSequenceCollection
                .FindAndModify(query, null, Update.Inc("seq", 1), true, true)
                .ModifiedDocument["seq"]
                .AsInt32;
        }

        public bool IsEmpty(object id)
        {
            return (int)id == 0;
        }
    }
}