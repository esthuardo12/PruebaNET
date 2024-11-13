using PruebaNET.DAL.DTOs;
using PruebaNET.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNET.BL.Interfaces
{
    public interface IProductos
    {
        Task<List<Product>> GetProducts();

        Task<ProductGetByIDDTO> GetProductAsync(int id);

        Task<bool> SetProductAsync(ProductDTO product);

        Task<bool> UpdateProductAsync (ProductDTO product,int id);

    }
}
