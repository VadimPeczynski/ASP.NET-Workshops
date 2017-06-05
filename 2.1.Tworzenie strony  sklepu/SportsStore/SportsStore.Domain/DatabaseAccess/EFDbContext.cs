using Microsoft.EntityFrameworkCore;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Domain.DatabaseAccess
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=G0ZCN12\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True");
        }
    }
}
