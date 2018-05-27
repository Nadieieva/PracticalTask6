using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class SignInModel
    {
        [Required]
        public string CardID { get; set; }
        
        [Required]
        public string PinCode { get; set; }
    }
}