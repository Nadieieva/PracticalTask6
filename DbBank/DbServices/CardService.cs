using System.Linq;

namespace BankDb.DbServices
{
    public class CardService
    {
        public bool IsExists(string cardId, string pinCode)
        {
            var isExists = false;
            using (var context = new BankContext())
            {
                isExists = context.Cards.Any(c => c.CardID == cardId && c.PinCode == pinCode);
            }
            return isExists;
        }

        public decimal GetBalance(string cardId)
        {
            decimal balance = 0;
            using (var context = new BankContext())
            {
                balance = context.Cards.SingleOrDefault(c => c.CardID == cardId).Ballance;
            }
            return balance;
        }
    }
}