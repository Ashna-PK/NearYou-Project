using Seller.Api.Data;
using Seller.Api.Models;

namespace Seller.Api.Repository.IRepository
{
    public interface IShopRepository
    {
        public Task<IEnumerable<Shop>> getShops();
        public Task<Shop> addShopDetails( ShopLoginDto shop);
        public Task<bool> deleteShop(int id);
        public Task<Shop> editShop(int id, shopDto shop);
        public Task<Shop> getShopById(int Id);
        public Task<bool> adminVerify(int id, bool isVerified, decimal rating);
        public  Task<shopIdName> getShopId(string username);
        public  Task<IEnumerable<Shop>> getVerifiedShop();

    }
}
