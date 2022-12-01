using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbMessageRepository : IDbMessageRepository
    {
        PizzeriaDbContext db;

        public DbMessageRepository(PizzeriaDbContext _db)
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
