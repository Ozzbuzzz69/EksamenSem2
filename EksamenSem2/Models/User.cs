using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EksamenProjekt2Sem.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Navnet skal være udfyldt")]
        [StringLength(50, ErrorMessage = "Navnet må max være 50 tegn langt")]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\s]+$", ErrorMessage = "Navnet må kun indeholde bogstaver og mellemrum")] // Regex til at sikre at der kun er bogstaver og mellemrum
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email må ikke være tomt")]
        [EmailAddress(ErrorMessage = "Indtast gyldig email adresse")]
        [StringLength(50, ErrorMessage = "Email må max være 50 tegn langt")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } // Bruges som login

        [Required(ErrorMessage = "Telefon nummer må ikke være tomt")]
        [RegularExpression(@"^+?[0-9]{8,10}$", ErrorMessage = "Indtast gyldigt telefonnummer")] // +45 12345678
        [StringLength(10, ErrorMessage = "Telefonnummeret må max være 10 tegn langt")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Kodeord må ikke være tomt")]
        [MinLength(8, ErrorMessage = "Koden skal minimum indeholde 8 tegn")]
        [MaxLength(20, ErrorMessage = "Koden må max være 20 tegn langt")]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Koden skal indeholde mindst 1 stort bogstav, 1 lille bogstav og 1 tal")] // "\d" konverter tal til en string
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User()
        { }

        public User(string name, string email, string phoneNumber, string password)
        { 
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

    }
}
