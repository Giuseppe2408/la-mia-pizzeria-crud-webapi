using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IPizzaRepository pizzaRepository;

        ICategoryRepository categoryRepository;

        IIngredientRepository ingredientRepository;

        public PizzaController(IPizzaRepository _pizzaRepository, ICategoryRepository _categoryRepository, IIngredientRepository _ingredientRepository)
        {
            pizzaRepository = _pizzaRepository;
            categoryRepository = _categoryRepository;
            ingredientRepository = _ingredientRepository;
        }

        public IActionResult Get()
        {
            List<Pizza> pizzas = pizzaRepository.All();

            return Ok(pizzas);
        }

        public IActionResult SearchTitle(string? title)
        {
            List<Pizza> pizzas = pizzaRepository.SearchByTitle(title);
            return Ok(pizzas);
        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            return Ok(pizza);
        }



    }
}
