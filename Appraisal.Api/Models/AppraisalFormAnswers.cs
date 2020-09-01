using System;
using System.Collections.Generic;

namespace Appraisal.Api.Models
{
    public  class AppraisalFormAnswers    
    {
        public string AppraisedValue { get; set; }
        public DateTime AppraisedDateTime { get; set; }
        public IEnumerable<AppraisalFormQuestionOption> AnsweredOption { get; set; }
    }
}