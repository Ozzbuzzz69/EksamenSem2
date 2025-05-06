using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EksamenProjekt2Sem.Models
{
    public class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Antal")]
        public int Quantity { get; set; }
        [Display(Name = "Total Pris")]
        
        public double Price { get; set; }
        public Food Food { get; set; }
        public CampaignOffer CampaignOffer { get; set; }
        
        public OrderLine()
        { }

        
        public OrderLine(int quantity, Food? food, CampaignOffer? campaign)
        {
            Quantity = quantity;
            Food = food;
            CampaignOffer = campaign;
        }
    }
}
