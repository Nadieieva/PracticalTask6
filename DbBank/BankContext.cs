using BankData;
using BankData.Models;
using BankDb.Mapping;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace BankDb
{
    public class BankContext: DbContext, IBankContext
    {
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Card> Cards { get; set; }


        #region DbContext

        static BankContext()
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        public BankContext() : base() { }

        public BankContext(string connName) : base("Name=" + connName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CardMapping());
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new OperationMapping()); 
        }
        #endregion

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

    }
}
