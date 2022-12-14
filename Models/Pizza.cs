using la_mia_pizzeria_static.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [StringLength(50, ErrorMessage = "Non può essere più lungo di 50 caratteri")]
        public string Nome { get; set; }

        [Column(TypeName = "text")]
        [ValidationParole]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        public string Image { get; set; }

        [Range(1, 100, ErrorMessage = "Inserisci un numero positivo")]
        public double Price { get; set; }


        //relazione con category colonna nel db 
        public int CategoryId { get; set; }
        //relazione istanza
        public Category? Category { get; set; }


        //relazione molti a molti con gli ingredienti
        public List<Ingredient>? Ingredients { get; set; }

        //relazione molti a molti con le review
        public List<Review>? Reviews { get; set; }

        public Pizza()
        {
        }

        public Pizza(string nome, string image, double price)
        {
            Nome = nome;
            Image = image;
            Price = price;
        }
    }
}
