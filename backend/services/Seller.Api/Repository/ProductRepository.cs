using Azure;
using Microsoft.EntityFrameworkCore;
using Seller.Api.Data;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;
using System.Text.Json;

namespace Seller.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SellerDbContext _context;
        public ProductRepository(SellerDbContext context)
        {
            _context = context;
        }
        public async Task<Product> addProductDetails(int shopId, ProductDto product)
        {
            Product product1 = new Product()
            {
                shopId = shopId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                quantity = product.quantity,
            };
            _context.products.Add(product1);
            await _context.SaveChangesAsync();

            return product1;
        }


        public async Task<bool> deleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product> editProduct(int id, ProductDto product)
        {
            var product1 = await _context.products.FindAsync(id);
            //_context.Entry(seller).State = EntityState.Modified;
            if (product1 == null)
            { return new Product(); }
            product1.quantity = product.quantity;
            product1.Price = product.Price;
            product1.Description = product.Description;
            product1.Name = product.Name;

            var result = _context.products.Any(e => e.Id == id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return new Product();
                }
                else
                {
                    throw;
                }
            }
            return product1;
        }

        public async Task<Product> getProductById(int Id)
        {
            var product = await _context.products.FindAsync(Id);

            if (product == null)
            {
                return new Product();
            }

            return product;
        }

        public async Task<IEnumerable<Product>> getProductsByShop(int SellerId)
        {
            var product = await _context.products.Where(x => x.shopId == SellerId).ToListAsync();
            return product;
        }
        public async Task<IEnumerable<Product>> getProducts()
        {
            return await _context.products.ToListAsync();

        }
        public async Task<Product> updateQuantity(int id,int quantity)
        {
            //var responseContent = await con.ReadAsStringAsync();

            // Deserialize the JSON string to an object of type `Product`
            //var product = JsonSerializer.Deserialize<content>(responseContent);
            var product1 = await _context.products.FindAsync(id);
            if (product1 == null)
            {
                return new Product();
            }
           
            product1.quantity -= quantity;
            
            await _context.SaveChangesAsync();
            return product1;
        }
    }
    //public class content
    //{
    //    public int productid { get; set; }
    //    public int quantity { get; set; }
    //}
}
