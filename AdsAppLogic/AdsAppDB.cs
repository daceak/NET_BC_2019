using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAppLogic
{
    public class AdsAppDB : DbContext
    {
        public AdsAppDB(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
