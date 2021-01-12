﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<Category>(ConfigureCategory);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(cb => cb.ProductName)
                .IsRequired()
                .HasMaxLength(100);

        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired();
            builder.Property(cb => cb.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
