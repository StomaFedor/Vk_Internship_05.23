using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vk_Internship.Database.Models;

namespace Vk_Internship.Database
{
    public class VkDbContext : DbContext
    {
        public VkDbContext(DbContextOptions<VkDbContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<User> Users { get; set; }

        public DbSet<User_group> User_groups { get; set; }

        public DbSet<User_state> User_states { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Created_Date).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<User_state>().Property(u => u.Code).HasDefaultValue(CodeState.Active);
            modelBuilder.Entity<User_group>().HasIndex(u => u.Code).HasFilter("\"Code\" = 'Admin'").IsUnique();
        }
    }
}
