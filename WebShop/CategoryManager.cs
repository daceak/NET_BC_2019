using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebShop
{
    public class CategoryManager : BaseManager<Category> //norada mainiga tipu (klase BaseManager aizstaj T) ar kadu izpildit metodes
    {
        //visas metodes ir pieejamas saja klase
        public CategoryManager(WebShopDB db) //ka parametru sanem datubazi
            : base(db) //ar so liniju izsauc bazes klases konstruktoru- izveido BaseManager
        {

        }

        //implement absract ipasibu-mainigoar override-enter
        protected override DbSet<Category> Table
        {
            get
            {
                return _db.Categories;
            }
        }

        public void Seed()
        {

        }
    }
}
