using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Item : BaseData
    {
        public decimal Price { get; set; } //decimal precizaks 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }

    }
}
