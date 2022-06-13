using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Data.Mapping;
using System;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options): base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Adminstrador",
                    Email = "dev.lucasrosa@gmail.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });
        }
    }
}
