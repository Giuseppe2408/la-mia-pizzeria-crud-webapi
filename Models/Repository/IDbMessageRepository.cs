namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IDbMessageRepository
    {
        List<Message> All();
        void Create(Message message);
    }
}