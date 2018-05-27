using BankData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDb
{
    public class BankService
    {
        public void InsertInitialData()
        {
            var dataToInsert = new List<Client> {
                new Client
                {
                    FirstName = "",
                    LastName = "",
                    Birthday = new DateTime(1990, 1, 1),
                    Phone = "",
                    Address = new Address
                    {

                        City = "",
                        Country = "",
                        TheAddress = "",
                        State = ""
                        
                    },
                    Cards =  new List<Card>
                    {
                        new Card
                        {
                            CardID = "0000000000000000",
                            Ballance = 0,
                            PinCode = "0000",
                            OutOperations = new List<Operation>
                            {
                                new Operation
                                {
                                    CardIn = "6578421056841245",
                                    Amount = 643.51M
                                },
                                new Operation
                                {
                                    CardIn = "9870213456751204",
                                    Amount = 1500.6M
                                }
                            }
                        }
                    }
                },
                new Client
                {
                    FirstName = "Anastasia",
                    LastName = "Petrova",
                    Phone = "+380504060548",
                    Birthday = new DateTime(1997, 5, 31),
                    Address = new Address
                    {
                        City = "Kherson",
                        State = "",
                        Country = "Ukraine",
                        TheAddress = "Perecopskaya 156"
                    },
                    Cards =  new List<Card>
                    {
                        new Card
                        {
                            CardID = "6578421056841245",
                            Ballance = 0,
                            PinCode = "5248",
                            OutOperations = new List<Operation>
                            {
                                new Operation
                                {
                                    CardIn = "9870213456751204",
                                    Amount = 350M
                                }
                            }
                        }
                    }
                },
                new Client
                {
                    FirstName = "Ivan",
                    LastName = "Kozlov",
                    Phone = "+380996743201",
                    Birthday = new DateTime(1988, 4, 12),
                    Address = new Address
                    {
                        Country = "Ukraine",
                        State = "",
                        City = "Kiev",
                        TheAddress = "Universitetska 12"
                    },
                    Cards =  new List<Card>
                    {
                        new Card
                        {
                            CardID = "9870213456751204",
                            Ballance = 0,
                            PinCode = "4390",
                            OutOperations = new List<Operation>
                            {
                                new Operation
                                {
                                    CardIn = "0000000000000000",
                                    Amount = 50.2M
                                }
                            }
                        }
                    }
                }
            };
            using (var context = new BankContext())
            {
                context.Clients.AddRange(dataToInsert);
                context.SaveChanges();
            }
        }

        public void RecalculateCardBalance(string cardId)
        {
            using (var context = new BankContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.CardID == cardId);

                context.Entry(card).Collection(c => c.InOperations).Load();
                context.Entry(card).Collection(c => c.OutOperations).Load();

                card.Ballance =
                    card.InOperations.Sum(o => o.Amount) - card.OutOperations.Sum(o => o.Amount);

                context.SaveChanges();

   
            }
        
        }
    }
}
