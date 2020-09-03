using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appraisal.Shared.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string AppraisalFormId { get; set; }
        public string Title { get; set; }
        public string BaseValue { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public bool Active { get; set; }
        public IEnumerable<Sku> Skus { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; }
    }
}