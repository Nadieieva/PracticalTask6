using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Card
    {
        public string CardID { get; set; }
        public int ClientId { get; set; } 
        public string PinCode { get; set; } 
        public decimal Ballance { get; set; } 

        public Client Client { get; set; }

        public List<Operation> InOperations { get; set; }
        public List<Operation> OutOperations { get; set; }

        public Card()
        {
            InOperations = new List<Operation>();
            OutOperations = new List<Operation>();
        }
    }
}
