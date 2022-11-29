namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IPizzaRepository
    {
        List<Pizza> All();
        void Create(Pizza pizza, List<int> selectedIngredients);
        Pizza GetById(int id);

        List<Pizza> SearchByTitle(string title);

        void MyRemove(Pizza pizza);
        void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients);
    }
}