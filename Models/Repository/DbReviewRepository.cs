using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Models.Repository
{

    public class DbReviewRepository : IReviewRepository
    {
        private PizzeriaDbContext db;

        public DbReviewRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }

        public List<Review> All()
        {
            return db.Reviews.ToList();
        }

        public void Create(Review review)
        {
            db.Add(review);
            db.SaveChanges();

        }
    }
}
