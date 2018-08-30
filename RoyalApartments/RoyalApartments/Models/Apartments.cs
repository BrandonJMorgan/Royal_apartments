using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoyalApartments.Models
{
    public class Apartments
    {
        [Key]
        public string Name { get; set; }
        public string Location { get; set; }
        public int Price { get; set; }
    }
}