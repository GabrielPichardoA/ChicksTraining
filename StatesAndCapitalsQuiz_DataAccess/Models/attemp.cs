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
    using System.ComponentModel;

    public partial class attemp
    {
        public int Id { get; set; }
        [DisplayName("User Id")]
        public Nullable<int> UserId { get; set; }
        public Nullable<int> FailedAttempts { get; set; }
    }
}
