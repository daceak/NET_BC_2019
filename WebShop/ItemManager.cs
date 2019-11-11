using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class ItemManager :BaseManager<Item>
    {

        public ItemManager(WebShopDB db)
            : base(db) //izsauc bazes konstruktoru
        {

        }

        protected override DbSet<Item> Table
        {
            get
            {
                return _db.Items;
            }
        }

        public List<Item> GetByCategory (int categoryId)
        {
            return _db.Items
                .Where(i => i.CategoryId == categoryId)
                .ToList(); //jaliek to list jo no datubazes neatgriez saraksta veida
        }

        /* public Item Update(Item item) //full description //Item
         {
             Item updatedItem = _db.Items.FirstOrDefault(i => i.Id == item.Id); //firstordefault izmanto lai datubazs tabula mekletu
             //katrai vertibai atseviski updatedItem.Title = item.Title
             updatedItem = item;
             _db.SaveChanges(); //lai saglabatu izmainas datubaze
             return updatedItem;
         }*/

        public void Seed() //so metodi atstaj jo unit testos ir ielikta un butu japarraksta so metodi
        {
        }
    }
}
