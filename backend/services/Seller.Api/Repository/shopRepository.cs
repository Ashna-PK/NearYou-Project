using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Seller.Api.Data;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;
using System.Collections;

namespace Seller.Api.Repository
{
    public class shopRepository:IShopRepository
    {
        private readonly SellerDbContext _context;
        public shopRepository(SellerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Shop>> getShops()
        {
            return await _context.shops.ToListAsync();

        }

        public async Task<Shop> getShopById(int Id)
        {
            var shop = await _context.shops.FindAsync(Id);

            if (shop == null)
            {
                return new Shop();
            }

            return shop;
        }
        public async Task<Shop> addShopDetails(ShopLoginDto shop)
        {
            //await _context.shops.AddAsync(shop);
            Shop shop1 = new Shop()
            {
                sellerName = shop.Name,
                Email=shop.Email,
                Address=shop.Address,
               
                PhoneNumber=shop.PhoneNo,
               
             };
            await _context.shops.AddAsync(shop1);
            await _context.SaveChangesAsync();

            return shop1;

        }
        public async Task<bool> deleteShop(int id)
        {
            var shop = await _context.shops.FindAsync(id);
            if (shop == null)
            {
                return false;
            }

            _context.shops.Remove(shop);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Shop> editShop(int id, shopDto shop)
        {
            var shopEdit = await _context.shops.FindAsync(id);
            //_context.Entry(seller).State = EntityState.Modified;
            if (shopEdit == null)
            { return new Shop(); }

            shopEdit.Name = shop.Name;
            shopEdit.Description = shop.Description;
            shopEdit.Address = shop.Address;
            shopEdit.latitude = shop.latitude;
            shopEdit.longitude = shop.longitude;
            shopEdit.Email = shop.Email;
            shopEdit.PhoneNumber=shop.PhoneNumber;
            shopEdit.isOpen = shop.isOpen;
            shopEdit.Category = shop.Category;
            shopEdit.openTime = shop.openTime;
            shopEdit.closeTime = shop.closeTime;
            var result = _context.shops.Any(e => e.Id == id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return new Shop();
                }
                else
                {
                    throw;
                }
            }
            return shopEdit;
        }
        public async Task<bool> adminVerify(int id, bool isVerified, decimal rating)
        {
            var shopEdit = await _context.shops.FindAsync(id);
            if (shopEdit == null)
            { return false; }
            shopEdit.IsVerified = isVerified;
            shopEdit.rating = rating;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<shopIdName> getShopId(string username)
        {
            var shop = await _context.shops.FirstOrDefaultAsync(x => x.Email == username);
            if (shop == null)
            {
                return null;
            }
            shopIdName s = new shopIdName()
            {
                shopId = shop.Id,
                shopName = shop.Name,
            };

            return s;
        }
        public async Task<IEnumerable<Shop>> getVerifiedShop()
        {
            var shops = await _context.shops.Where(x => x.IsVerified == true).ToListAsync();
            return shops;

        }
    }
    public class shopIdName
    {
        public int shopId { get; set; }
        public string shopName { get; set; }
    }
}
