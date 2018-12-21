using Microsoft.EntityFrameworkCore;
using NewsPublish.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Service
{
    public class Db:DbContext
    {
        public Db():base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=WYT\MSSQLSERVER2016;Initial Catalog=NewsPublish;User ID=sa;Password=123456",b=>b.UseRowNumberForPaging());
            //optionsBuilder.UseSqlServer(@"Data Source=172.16.6.184;Initial Catalog=NewsPublish;User ID=sa;Password=123456", b => b.UseRowNumberForPaging());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Banner> Banner { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsClassify> NewsClassify { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
    }
}
