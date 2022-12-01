using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        public List<Pizza>? Pizzas { get; set; }
    }
}
