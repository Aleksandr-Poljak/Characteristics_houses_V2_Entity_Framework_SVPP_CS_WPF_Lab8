using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models
{
    public class HouseContext : DbContext
    { 
        public HouseContext() 
        {
            Database.EnsureCreated();
        }

        public DbSet<House> Houses { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DafaultConnection"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
