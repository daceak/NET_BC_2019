﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class CategoryManager
    {
        public List<Category> Categories;
        int currentId;
        public CategoryManager()
        {
            Categories = new List<Category>();
            currentId = 100;
        }
        public Category Create(Category category)
        {
            category.Id = currentId;
            Categories.Add(category);
            currentId++;
            return category;
        }

        public List<Category> GetAll()
        {
            return Categories;
        }
        public Category Get(int categoryid)
        {
            return Categories.Find(c => c.CategoryId == categoryid);
        }

        public void Seed()
        {
            Categories.Add(new Category()
            {
                Id = 1,
                Title = "Test category 1",
                CategoryId = 3
            }); ;

            Categories.Add(new Category()
            {
                Id = 2,
                Title = "Test category 2",
                CategoryId = 2
            }); ;
        }
    }
}
