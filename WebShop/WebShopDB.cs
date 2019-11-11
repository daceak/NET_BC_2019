using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class WebShopDB : DbContext //webshopDB atbilst entity framework db context. DB context (C# klase) ir veids(pieeja) ka sasaistit SQL un C#
    {
        public WebShopDB(DbContextOptions options) //konstruktors ar so parametru sanem info par datubazi
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } //tabulas nosaukums Categories/ Category parametri kas bus tabula
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
