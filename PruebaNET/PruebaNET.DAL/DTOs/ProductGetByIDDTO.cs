using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.DAL.DTOs
{
    public class ProductGetByIDDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string StatusName { get; set; }

        public int? Stock { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? Discount { get; set; }

        public decimal? FinalPrice { get; set; }
    }
}
