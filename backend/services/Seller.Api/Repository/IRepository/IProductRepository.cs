using Seller.Api.Data;
using Seller.Api.Models;

namespace Seller.Api.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> getProducts();
        public Task<Product> addProductDetails(int sellerId, ProductDto product);
        public Task<bool> deleteProduct(int id);
        public Task<Product> editProduct(int id, ProductDto product);
        public Task<Product> getProductById(int SellerId);
        public Task<Product> updateQuantity(int id,int quantity);
        public Task<IEnumerable<Product>> getProductsByShop(int SellerId);
    }
}
