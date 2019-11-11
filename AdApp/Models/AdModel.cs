using AdsAppLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdApp.Models
{
    public class AdModel
    {
        //visas ipasibas jaliek atseviski, nevar nemt Ad gatavo klasi
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        [Required]
        public int? Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Place { get; set; }
        public DateTime Placed { get; set; }
        public List<Category> Categories { get; set; }
    }
}
