using System.Collections.Generic;
using System.Linq;
using BankData.Models;

namespace BankDb.DbServices
{
    public class OperationService
    {
        public void WithdrawFunds(string cardId, decimal amount)
        {
            using (var context = new BankContext())
            {
                var atm = context.Cards.SingleOrDefault(c => c.CardID == "0000000000000000");
                var card = context.Cards.SingleOrDefault(c => c.CardID == cardId);
                card.Ballance = card.Ballance - amount;
                atm.Ballance = atm.Ballance + amount;
                var operation = new Operation
                {
                    CardIn = atm.CardID,
                    CardOut = card.CardID,
                    Amount = amount,
                    BalanceOnInCard = atm.Ballance,
                    BalanceOnOutCard = card.Ballance
                };
                context.Operations.Add(operation);
                context.SaveChanges();
            }
        }

        public List<Operation> AllOperations(string cardId)
        {
            var operations = new List<Operation>();
            using (var context = new BankContext())
            {
                operations = context.Operations.Where(o => o.CardIn == cardId || o.CardOut == cardId).ToList();
            }
            return operations;
        }
    }
}