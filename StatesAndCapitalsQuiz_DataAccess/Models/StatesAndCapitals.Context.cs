﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_Entities : DbContext
    {
        public DB_Entities()
            : base("name=DB_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<State> States { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Profile> User_Profile { get; set; }
        public DbSet<attemp> attemps { get; set; }
    }
}
