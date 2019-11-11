using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdsAppLogic
{
    public class AdManager : BaseManager<Ad>
    {

        public AdManager(AdsAppDB db)
            :base(db)
        {
            
        }

        protected override DbSet<Ad> Table
        {
            get
            {
                return _db.Ads;
            }
        }

        public List<Ad> GetByCategoryId(int id)
        {
            return _db.Ads.Where(a => a.CategoryId == id).ToList();
        }

        public List<Ad> GetUserAds (string email)
        {
            List<Ad> ads = Table.Where(a => a.Email == email).ToList();
            return ads;
        }

        public void Seed()
        {
           /* Ads.Add(new Ad()
            {
                Id = 1,
                Price = 300.90,
                Title = "Apple Iphone 6s",
                Description = "Apple iPhone 6s Plus smartphone. Announced Sep 2015. Features 5.5″ IPS LCD display, Apple A9 chipset, 12 MP primary camera, 5 MP front camera.",
                Photo = "https://images-na.ssl-images-amazon.com/images/I/515nILxCqdL._SY500_.jpg",
                CategoryId = 3,
                Phone = 23456789,
                Email = "dace@sales.lv",
                Place = "Riga",
                Placed = DateTime.Now.ToString("dd/MM/yyyy"),
            }) ;

            Ads.Add(new Ad()
            {
                Id = 2,
                Price = 700.90,
                Title = "Apple Iphone X",
                Description = "At a Glance. The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor.",
                Photo = "https://cdn.macrumors.com/article-new/2017/09/iphonexdesign.jpg",
                CategoryId = 4,
                Phone = 23456789,
                Email = "dace@sales.lv",
                Place = "Riga",
                Placed = DateTime.Now.ToString("dd/MM/yyyy"),
            });

            Ads.Add(new Ad()
            {
                Id = 3,
                Price = 800.90,
                Title = "Apple Iphone XS",
                Description = "Apple's new phone comes in two sizes: the iPhone XS, with a 5.8-inch display, and the iPhone XS Max, with a 6.5-inch display.",
                Photo = "https://sites.create-cdn.net/siteimages/58/3/5/583539/16/9/1/16913213/1000x1000.png?1543480824",
                CategoryId = 4,
                Phone = 23456789,
                Email = "dace@sales.lv",
                Place = "Riga",
                Placed = DateTime.Now.ToString("dd/MM/yyyy"),
            });

            Ads.Add(new Ad
            {
                Id = 4,
                Price = 500.90,
                Title = "Samsung Galaxy S10",
                Description = "description not available",
                Photo = "https://image-us.samsung.com/us/smartphones/galaxy-s10/gallery/s10/prism-blue/001_Gallery_G973_Blue_1600x1200.jpg",
                CategoryId = 5,
                Phone = 23456789,
                Email = "dace@sales.lv",
                Place = "Riga",
                Placed = DateTime.Now.ToString("dd/MM/yyyy"),
            });*/
        }
    }
}
