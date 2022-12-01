namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IReviewRepository
    {
        List<Review> All();
        void Create(Review review);
    }
}