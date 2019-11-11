using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAppLogic //New Project - Class Library (.Net framework) 
{
    public class Ad : BaseData
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Place { get; set; }
        public DateTime Placed { get; set; }

    }
}
