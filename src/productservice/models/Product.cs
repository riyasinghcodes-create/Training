using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productservice.models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}