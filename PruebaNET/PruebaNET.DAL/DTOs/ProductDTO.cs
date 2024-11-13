using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.DAL.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;

        public int Status { get; set; }

        public int? Stock { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}
