using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Online_Store__React_ASPX_.Models
{
    public class FoodItems
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; } 

        [NotMapped]
        public int Quantity { get; set; }
        [NotMapped]
        public string Comment { get; set; }


    }
}