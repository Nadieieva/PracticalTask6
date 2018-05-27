using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public string SSN { get; set; }
        public Address Address { get; set; }

        public virtual List<Card> Cards { get; set; }

        public Client ()
        {
            Cards = new List<Card>();
        }

    }
}
