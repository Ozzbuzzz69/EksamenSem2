using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EksamenProjekt2Sem.Models
{
    public abstract class Food
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Ingredienser")]
        [Required(ErrorMessage = "Der skal angives ingredienser")]
        [StringLength(100, ErrorMessage = "Maks 100 tegn")]
        public string Ingredients { get; set; }
        public bool? InSeason { get; set; }
        public string? MeatType { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        [Range(0, 1000, ErrorMessage = "Prisen skal være mellem 0 og 1000")]
        public double Price { get; set; }

        public Food()
        { }

        
        public Food(int id,string ingredients, bool? inSeason, string? meatType, double price)
        {
            Id = id;
            Ingredients = ingredients;
            InSeason = inSeason;
            MeatType = meatType;
            Price = price;
        }
    }
}