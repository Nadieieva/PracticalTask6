using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class WithdrawFundsModel
    {
        [Required]
        public string Amount { get; set; }
    }
}