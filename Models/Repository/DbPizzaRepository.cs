﻿using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models.Form;
using lamiapizzeriastatic.Migrations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbPizzaRepository : IPizzaRepository
    {
        private PizzaDbContext db;

        public DbPizzaRepository(PizzaDbContext _db)
        {
            db = _db;
        }

        public List<Pizza> All()
        {
            return db.Pizzas.Include(pizza => pizza.Category).Include(p => p.Ingredients).ToList();
        }

        //public List<Pizza> AllWithRelations()
        //{
            
        //}

        public Pizza GetById(int id)
        {
            return db.Pizzas.Where(p => p.Id == id).Include(p => p.Category).Include(p => p.Ingredients).FirstOrDefault();
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Ingredients = new List<Ingredient>();

            foreach (int ingredientId in selectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }

            //aggiungo al db la pizza con i nuovi ingredienti
            db.Add(pizza);

            db.SaveChanges();
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {
            pizza.Nome = formData.Nome;
            pizza.Image = formData.Image;
            pizza.Description = formData.Description;
            pizza.Price = formData.Price;
            pizza.CategoryId = formData.CategoryId;

            pizza.Ingredients.Clear();

            if (selectedIngredients == null)
            {
                selectedIngredients = new List<int>();
            }

            foreach (int ingredientId in selectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }




            db.SaveChanges();
        }

        public void MyRemove(Pizza pizza)
        {
            db.Remove(pizza);
            db.SaveChanges();
        }

        public List<Pizza> SearchByTitle(string title)
        {
            IQueryable<Pizza> query = db.Pizzas.Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients);


            if (title == null)
            {
                return query.ToList();

            }

            

            return query.Where(pizza => pizza.Nome.ToLower().Contains(title.ToLower())).ToList();
            
        }
    }

}
