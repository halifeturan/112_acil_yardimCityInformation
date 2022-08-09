
using CityInformation.Models.Entities;
using CityInformation.Models.Entities;
using EntityFrameworkCore.EncryptColumn;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInformation.Models
{
    public class Context:DbContext
    {

        public DbSet<CityProp> CityProp { get; set; }
        public DbSet<Authorized> Authorized { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQlLocalDb;Initial Catalog=cityInformation;Integrated Security=true");
        }
  
        
    }
}
