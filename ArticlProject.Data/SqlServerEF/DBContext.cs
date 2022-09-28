using ArticlProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlProject.Data.SqlServerEF
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ArticlProjectDB;Trusted_Connection=True");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
