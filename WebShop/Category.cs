using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Category : CategoryManager
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; } //ja nav ? tad datu tips nav nullejams un vertibai vienmer ir jabut
    }
}
