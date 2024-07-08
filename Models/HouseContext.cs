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
        public string ConnectionName { get; private set; }

        public HouseContext(string connectionName = "DafaultConnection") 
        {
            ConnectionName = connectionName;
            Database.EnsureCreated();
            SeedData();       
        }

        public DbSet<House> Houses { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);
        }

        private void SeedData()
        {
            if(!Houses!.Any())
            {
                House h1 = new("Минск", "Одинцова", 14);
                House h2 = new("Минск", "Одоевского", 12, 34, true, 12, 23453, "Кузнецов А.С.");
                House h3 = new("Минск", "Одоевского", 15, 25, false, 4, null, "Тарасов С.Е");
                Houses.Add(h1);
                Houses.Add(h2);
                Houses.Add(h3);
                SaveChanges();
            }
        }

    }
}
