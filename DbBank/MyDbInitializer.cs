using System;
using System.Collections.Generic;
using System.Data.Entity;
using BankData.Models;

namespace BankDb
{
    public class MyDbInitializer: CreateDatabaseIfNotExists<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            context.Clients.Add(new Client
            {
                FirstName = "",
                LastName = "",
                Address = new Address
                {
                    Country = "",
                    City = "",
                    State = "",
                    TheAddress = ""
                },
                Cards = new List<Card>
                {
                    new Card
                    {
                        CardID= "0000000000000000",
                        PinCode = "0000",
                        Ballance = 0
                    }
                }
            });
            
            context.Clients.Add(new Client
            {
                FirstName = "Viktoriia",
                LastName = "Nadieieva",
                Birthday = new DateTime(1997, 5, 31),
                Address = new Address
                {
                    Country = "Ukraine",
                    City = "Kherson",
                    State = "",
                    TheAddress = "Torpedniy"
                },
                Cards = new List<Card>
                {
                    new Card
                    {
                        CardID= "5281326889890891",
                        PinCode = "2185",
                        Ballance = 5000
                    }
                }
            });
        }
    }
}