using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeSeriesApp.Models
{
    public class TimeSeriesDBContext : DbContext { 



        public TimeSeriesDBContext(): base("name=TimeSeriesDB") 
        {    }

        public DbSet<CategoryNode> Categories { get; set; }
        public DbSet<TimeSeries> TimeSeries { get; set; }

        public DbSet<SeriesPoints> SeriesPoints { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table

            modelBuilder.Entity<TimeSeries>().ToTable("TimeSeries");
            modelBuilder.Entity<CategoryNode>().ToTable("CategoryNode", "dbo");
        }

    }
}