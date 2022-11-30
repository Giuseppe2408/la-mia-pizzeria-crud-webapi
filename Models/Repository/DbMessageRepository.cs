using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbMessageRepository 
    {
        PizzaDbContext db;

        public DbMessageRepository(PizzaDbContext _db)
        {
            db = _db;
        }

        public List<Message> All()
        {
            return db.Messages.ToList();
        }

        public void Create(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }
    }
}
