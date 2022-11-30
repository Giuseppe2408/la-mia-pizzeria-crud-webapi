using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class GuestController : Controller
    {
        IPizzaRepository pizzaRepository;

        private ICategoryRepository categoryRepository;

        private IIngredientRepository ingredientRepository;

        public GuestController(IPizzaRepository _pizzaRepository, ICategoryRepository _categoryRepository, IIngredientRepository _ingredientRepository)
        {
            pizzaRepository = _pizzaRepository;
            categoryRepository = _categoryRepository;
            ingredientRepository = _ingredientRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.All();
            return View(categories);
        }

        public IActionResult Show(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);
            return View(pizza);
        }

        public IActionResult Contact()
        {          
            return View();
        }

    }
}
