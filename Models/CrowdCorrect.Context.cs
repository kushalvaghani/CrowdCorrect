﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrowdCorrect.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CrowdCorrectEntities : DbContext
    {
        public CrowdCorrectEntities()
            : base("name=CrowdCorrectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserKeywordTag> UserKeywordTags { get; set; }
    }
}
