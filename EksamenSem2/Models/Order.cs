using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EksamenProjekt2Sem.Models
{
    public class Order
    {
        private DateTime pickupTime;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderTime { get; } = DateTime.Now;

        [Required(ErrorMessage = "Der skal angives en afhentningstid")]
        [DataType(DataType.DateTime)]
        public DateTime PickupTime
        {
            get => pickupTime; set
            {

                if (PickupTime < DateTime.Now || PickupTime == DateTime.Now.AddDays(1))
                {
                    throw new ArgumentNullException("Ugyldig dato");
                }

            }
        }

        public double TotalPrice { get; set; }

        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public Order()
        { }

        
        public Order(User user, DateTime pickupTime)
        {
            User = user;
            PickupTime = pickupTime;
        }
    }
}
