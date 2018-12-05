using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarLand.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product description")]
        public string Description { get; set; }

        [Required]
        [Range(.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter a guitar type")]
        public string GuitarType { get; set; }

        [Required(ErrorMessage = "Please enter the guitar's body material")]
        public string BodyMaterial { get; set; }

        [Required(ErrorMessage = "Please enter the type of pickups")]
        public string Pickups { get; set; }
    }
}
