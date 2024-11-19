using Seller.Api.Models;

namespace Seller.Api.Repository.IRepository
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> getReviewByShop(int shopid);
        public Task<Review> getReviewById(int id);
        public Task<IEnumerable<Review>> getAllReview();

        public Task<bool> postReview(Review review);

    }
}
