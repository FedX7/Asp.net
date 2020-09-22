using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Many1.Models
{
    public class TeamContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }


        
    }
}