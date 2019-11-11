using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAppLogic
{
    public class Category : BaseData
    {
        public string Title { get; set; }
        public int? CategoryId { get; set; } //ja nav ? tad datu tips nav nullejams un vertibai vienmer ir jabut

        [NotMapped] //datubaze so mainigo nenemt vera. virtual column
        public int AdCount { get; set; }

    }
}
