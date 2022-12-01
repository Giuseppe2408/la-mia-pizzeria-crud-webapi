using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbCategoryRepository : ICategoryRepository
    {

        private PizzeriaDbContext db;

        public DbCategoryRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }

        public List<Category> All()
        {
            return db.Categories.ToList();

            
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(cat => cat.Id == id).FirstOrDefault();

            
        }

        public Category SearchById(int id)
        {
            return db.Categories.Where(cat => cat.Id == id).Include(c => c.Pizzas).FirstOrDefault();
        }


        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category, Category formData)
        {
            category.Title = formData.Title;
            db.SaveChanges();
        }

        public Category GetByIdWithPizza(int id)
        {
            return db.Categories.Where(c => c.Id == id).Include(c => c.Pizzas).FirstOrDefault();
        }

        public void Delete(Category category)
        {
            db.Remove(category);
            db.SaveChanges();

        }

        
    }
}
