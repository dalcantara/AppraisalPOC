using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appraisal.Api.Models
{
    public class Appraisal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Product Product { get; set; }
        public AppraisalForm AppraisalForm { get; set; }
        public IEnumerable<AppraisalFormAnswers> AppraisalFormAnswers { get; set; }
    }
}