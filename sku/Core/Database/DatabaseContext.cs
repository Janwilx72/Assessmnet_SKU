using System;
using Microsoft.EntityFrameworkCore;
using sku.Core.Entities;

namespace sku.Core.Database
{
	public class DatabaseContext : DbContext
	{
        public DbSet<SkuEntity> Skus { get; set; }
        public DbSet<AttributeEntity> Attributes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=skuDatabase.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeEntity>()
                .HasOne(x => x.Sku)
                .WithOne(x => x.Attribute);

            base.OnModelCreating(modelBuilder);


        }
    }
}

