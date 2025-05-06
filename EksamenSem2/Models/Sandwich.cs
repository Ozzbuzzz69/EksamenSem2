using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EksamenProjekt2Sem.Models
{
    public class Sandwich : Food
    {
        [Display(Name = "Kategori")]
        public string Category { get; set; }

       
        public Sandwich()
        { }

        
        public Sandwich(int id, string ingredients, bool? inSeason, string? meatType, double price, string category) : base(id, ingredients, inSeason, meatType, price)
        {
            Category = category;
        }
      
    }
}
