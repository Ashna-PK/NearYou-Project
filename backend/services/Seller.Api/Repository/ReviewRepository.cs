using Microsoft.EntityFrameworkCore;
using Seller.Api.Data;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;

namespace Seller.Api.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly SellerDbContext _context;
        public ReviewRepository(SellerDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Review>> getAllReview()
        {
            return await _context.reviews.ToListAsync();
        }
        public async  Task<IEnumerable<Review>> getReviewByShop(int shopId)
        {
             return await _context.reviews.Where(x=>x.shopid==shopId).ToListAsync();
        }

        public async Task<Review> getReviewById(int id)
        {
            var result= await _context.reviews.FindAsync(id);
            if(result==null)
                return new Review();
            return result;
        }

        public async Task<bool> postReview(Review review)
        {
           var rev= _context.reviews.Add(review);
            await _context.SaveChangesAsync();
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == review.productId);
            if(product!=null)
            {
                product.count++;
                product.cumulativeSum += review.userRating;
                product.rating=product.cumulativeSum/product.count;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
