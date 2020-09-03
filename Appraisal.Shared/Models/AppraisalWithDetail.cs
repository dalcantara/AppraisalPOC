using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Appraisal.Shared.Models
{
    public class AppraisalWithDetail
    {
        public AppraisalWithDetail(Appraisal appraisal)
        {
            Id = appraisal.Id;
            AppraisalForm = appraisal.AppraisalForm;
            ProductSummary = new Product()
            {
                Id = appraisal.Product.Id,
                AppraisalFormId = appraisal.Product.AppraisalFormId,
                BaseValue = appraisal.Product.BaseValue
            };
            AppraisalFormAnswers = appraisal
                .AppraisalFormAnswers
                .OrderByDescending(a => a.AppraisedDateTime)
                .First();
            var count = appraisal.AppraisalFormAnswers.Count();
            AppraisalFormAnswersHistory = appraisal.AppraisalFormAnswers.Take(count - 1);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public new string Id { get; set; }

        public new Product ProductSummary { get; set; }
        public new AppraisalForm AppraisalForm { get; set; }
        public new AppraisalFormAnswers AppraisalFormAnswers { get; set; }

        public IEnumerable<AppraisalFormAnswers> AppraisalFormAnswersHistory { get; set; }
    }
}