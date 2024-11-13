using PruebaNET.DAL.Models;
using PruebaNET.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET.DAL.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Reflection.Metadata.Ecma335;

namespace PruebaNET.BL.Clase
{
    public class LogicaProducto: IProductos
    {
        private PruebaNetContext db;
        private readonly IMemoryCache _memoryCache;

        public LogicaProducto( PruebaNetContext db , IMemoryCache memoryCache)
        {
            this.db=db;
            _memoryCache = memoryCache;
        }

        public async Task<ProductGetByIDDTO> GetProductAsync(int id)
        {
            var producto = await db.Products.Where(x => x.ProductId == id).FirstAsync();
            if (producto == null) return null;

            Status status = await GetStatusCacheAsync(producto.Status);
            int discount = await GetDiscount(producto.ProductId);
            var descuento = ((100.00m - discount) / 100.00m);
            decimal? precioFinal = producto.Price * descuento;
            var productoReturn = new ProductGetByIDDTO
            {
                ProductId = producto.ProductId,
                Name = producto.Name,
                StatusName = status.StatusName,
                Stock = producto.Stock,
                Description = producto.Description,
                Price = producto.Price,
                Discount = discount,
                FinalPrice = precioFinal
            };

            return productoReturn;
        }

        public async Task<List<Product>> GetProducts() 
        {
            return db.Products.ToList();
        }

        public async Task<bool> SetProductAsync(ProductDTO product)
        {
            var nuevoProducto = new Product
            {
                Name = product.Name,
                Status = product.Status,
                Stock = product.Stock,
                Description = product.Description,
                Price = product.Price
            };
            await db.Products.AddAsync(nuevoProducto);
            await db.SaveChangesAsync();
            return nuevoProducto.ProductId != 0 ? true: false;
        }

        public async Task<bool> UpdateProductAsync(ProductDTO product,int id)
        {
            var producto = db.Products.First(x => x.ProductId==id);
            if (producto != null) { 
                producto.Name = product.Name;
                producto.Status = product.Status;
                producto.Stock = product.Stock;
                producto.Description = product.Description;
                producto.Price = product.Price;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Status> GetStatusCacheAsync(int id)
        {
            List<Status> status = null;

            if (_memoryCache.TryGetValue("status", out status))
            {
                Console.WriteLine("obtenido de caché");
            }
            else
            {
                status = db.Statuses.ToList();
                _memoryCache.Set("status", status, TimeSpan.FromMinutes(5));
            }
            foreach(Status statusreturn in status)
            {
                if(statusreturn.Status1 == id) return statusreturn;
            }
            

            return null;
        }

        public async Task<int> GetDiscount(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var endpoint = new Uri("https://6733ce87a042ab85d1180dbc.mockapi.io/Products/discount/" + id);
                    var result = client.GetAsync(endpoint).Result;
                    var json = result.Content.ReadAsStringAsync().Result;
                    IDiscount objeto = JsonConvert.DeserializeObject<IDiscount>(json)!;
                    if (objeto.Discount > 100) return 0;
                    return objeto.Discount;
                }
            }
            catch
            {
                return 0;
            }
            
            return 0;
        }
    }
}
