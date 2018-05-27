using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Operation
    {
        public int OperationID { get; set; }
        public string CardIn { get; set; }
        public string CardOut { get; set; }

        public DateTime OperationTime { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceOnOutCard { get; set; }
        public decimal BalanceOnInCard { get; set; }
        
        public Card In { get; set; }
        public Card Out { get; set; }

        public Operation()
        {
            OperationTime = DateTime.Now;
        }
    }
}
