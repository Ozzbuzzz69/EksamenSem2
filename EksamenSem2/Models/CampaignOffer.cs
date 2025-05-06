using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace EksamenProjekt2Sem.Models
{
    public class CampaignOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Maks 100 tegn")]
        public string Name { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [Required]
        public double Price { get; set; }
        
        public CampaignOffer()
        { }
        
       
        public CampaignOffer(int id, string name, string imageLink, double price)
        {
            Id = id;
            Name = name;
            ImageLink = imageLink;
            Price = price;
        }
    }
}
