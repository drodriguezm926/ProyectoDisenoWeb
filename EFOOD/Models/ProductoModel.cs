using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFOOD.Models
{
    public class ProductoModel
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string FoodOptionCode { get; set; }
        public string ProductContent { get; set; }
        public byte[] ProductImage { get; set; }
    }
}