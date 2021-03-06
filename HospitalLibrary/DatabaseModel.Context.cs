﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalEntities : DbContext
    {
	    private static volatile HospitalEntities _entity;
	    private static object _lockObjeck = new object();
        public HospitalEntities()
            : base("name=HospitalEntities")
        {
        }

	    public static HospitalEntities GetEntity()
	    {
		    if (_entity == null)
			    lock (_lockObjeck)
				    if (_entity == null)
					    _entity = new HospitalEntities();
		    return _entity;
	    }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Card> cards { get; set; }
        public DbSet<Diagnosis> diagnosis { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<Session> sessions { get; set; }
        public DbSet<User> users { get; set; }
    }
}
