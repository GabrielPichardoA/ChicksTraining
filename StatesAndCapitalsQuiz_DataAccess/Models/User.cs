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

    public partial class User
    {
        public User()
        {
            this.TestResults = new HashSet<TestResult>();
        }

        [DisplayName("User Id")]
        public int UserId { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
