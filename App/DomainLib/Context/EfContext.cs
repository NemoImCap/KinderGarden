﻿using System.Data.Entity;

namespace DomainLib.Context
{
    public class EfContext : DbContext
    {
        public EfContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Kindergarden> Kindergardens { get; set; }
        public DbSet<Child> Children { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>().HasOptional(x => x.Kindergarden);
            modelBuilder.Entity<Kindergarden>()
                .HasMany(s => s.Children)
                .WithOptional(s => s.Kindergarden)
                .HasForeignKey(s => s.GartenId)
                .WillCascadeOnDelete(false);
        }
    }
}