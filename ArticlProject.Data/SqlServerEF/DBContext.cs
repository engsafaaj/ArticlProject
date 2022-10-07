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
            optionsBuilder.UseSqlServer(@"Server=SQL8001.site4now.net;Database=db_a8d0a9_articlprojectdb;User Id=db_a8d0a9_articlprojectdb_admin;Password=FeN@LuQZNQ9Mtju;timeout=120");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorPost> AuthorPost { get; set; }
    }
}
