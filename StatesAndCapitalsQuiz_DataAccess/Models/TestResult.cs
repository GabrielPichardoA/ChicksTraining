//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatesAndCapitalsQuiz_DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestResult
    {
        public int TestResultId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> TestDateTime { get; set; }
        public Nullable<int> TotalQuestions { get; set; }
        public Nullable<int> NumberCorrect { get; set; }
    
        public virtual User User { get; set; }
    }
}
