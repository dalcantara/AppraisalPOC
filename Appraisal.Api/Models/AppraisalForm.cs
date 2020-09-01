using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appraisal.Api.Models
{
    public class AppraisalForm
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AppraisalFormQuestion> Questions { get; set; }
    }

    public class AppraisalFormQuestion
    {
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public IEnumerable<AppraisalFormQuestionOption> Options { get; set; }
    }

    public class AppraisalFormQuestionOption
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}