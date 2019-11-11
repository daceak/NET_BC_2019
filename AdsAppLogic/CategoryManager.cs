using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdsAppLogic
{
    public class CategoryManager : BaseManager<Category>
    {

        public CategoryManager(AdsAppDB db)
            :base(db)
        {

        }

        protected override DbSet<Category> Table
        {
            get
            {
                return _db.Categories;
            }
        }

        public void Seed()
        {
            /*Categories.Add(new Category()
            {
                Id = 1,
                Title = "Samsung"
            });

            Categories.Add(new Category()
            {
                Id = 2,
                Title = "Apple"
            });

            Categories.Add(new Category()
            {
                Id = 3,
                Title = "Pre owned phones",
                CategoryId = 2
            });

            Categories.Add(new Category()
            {
                Id = 4,
                Title = "New phones",
                CategoryId = 2
            });

            Categories.Add(new Category()
            {
                Id = 5,
                Title = "Pre owned phones",
                CategoryId = 1
            });*/
        }
    }
}
