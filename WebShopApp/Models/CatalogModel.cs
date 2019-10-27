using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop;

namespace WebShopApp.Models
{
    public class CatalogModel //modelis, lai realizetu vajadzivo modeli, apvienojot klases viena modeli- jauna klase.
    {
        public List<Item> Items { get; set; }
        public List<Category> Categories { get; set; }

        public List<Item> AllItems { get; set; }

    }
}
