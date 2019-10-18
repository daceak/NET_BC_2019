using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class ItemManager
    {
        private int currentId;
        public List<Item> Items;

        public ItemManager()
        {
            Items = new List<Item>();
            currentId = 100;
        }
        public List<Item> GetByCategory (int categoryId)
        {
            return Items.FindAll(i => i.CategoryId == categoryId);
        }

        public Item Create(Item item)
        {
            item.CategoryId = currentId;
            Items.Add(item);
            currentId++;
            return item;
        }

        public Item Update(Item item) //full description //Item
        {
            Item updatedItem = Items.Find(i => i.Id == item.Id);
            updatedItem = item;
            return updatedItem;
        }

        public void Delete(Item item)
        {           
            Items.Remove(Items.Find(i => i.Id == item.Id));
        }

        public Item Get(int id)
        {
            Item item = Items.Find(i => i.Id == id);
            return item;
        }

        public void Seed()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Price = 10.11,
                Title = "Test Title 1",
                Description = "This is item 1 description",
                CategoryId = 2
            });

            Items.Add(new Item()
            {
                Id = 2,
                Price = 20.11,
                Title = "Test Title 2",
                Description = "This is item 2 description",
                CategoryId = 4
            }); ;
        }
    }
}
