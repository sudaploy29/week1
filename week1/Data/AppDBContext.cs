﻿using Microsoft.EntityFrameworkCore;
using week1.Models;
using System;
using System.Collections.Generic;

namespace week1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new List<Role>()
               {
                    new Role(){ Id = Guid.NewGuid(), Name = "user"},
                    new Role(){ Id = Guid.NewGuid(), Name = "Manager"},
                    new Role(){ Id = Guid.NewGuid(), Name = "Admin"},
                    new Role(){ Id = Guid.NewGuid(), Name = "Developer"}
               });
        }

//ครั้งแรกกที่มีอยู่แล้ว
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
//ตัวที่ต้องการเพิ่มเข้าไปป
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockMarket> Stockmarkets { get; set; }
    }
}