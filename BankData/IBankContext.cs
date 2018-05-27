using BankData.Models;
using System;
using System.Data.Entity;

namespace BankData
{
    public interface IBankContext: IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Operation> Operations { get; set; }
        DbSet<Card> Cards { get; set; }

        int SaveChanges();
    }
}
