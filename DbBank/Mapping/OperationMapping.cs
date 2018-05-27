using BankData.Models;
using System.Data.Entity.ModelConfiguration;

namespace BankDb.Mapping
{
    public class OperationMapping: EntityTypeConfiguration<Operation>
    {
        public OperationMapping()
        {
            ToTable("Operations", "dbo");
            HasKey(o => o.OperationID);

            Property(o => o.OperationID).HasColumnName("OperationID").HasColumnType("int").IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(o => o.CardOut).HasColumnName("CardOut").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(o => o.CardIn).HasColumnName("CardIn").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16);
            Property(o => o.Amount).HasColumnName("Amount").HasColumnType("money").IsRequired().HasPrecision(19, 4);
            Property(o => o.OperationTime).HasColumnName("OperationTime").HasColumnType("datetime2").IsRequired();
            Property(o => o.BalanceOnInCard).HasColumnName("BalanceOnInCard").HasColumnType("money").IsRequired().HasPrecision(19, 4);
            Property(o => o.BalanceOnOutCard).HasColumnName("BalanceOnOutCard").HasColumnType("money").IsRequired().HasPrecision(19, 4);               

            // Foreign keys
            HasRequired(a => a.In).WithMany(b => b.InOperations).HasForeignKey(c => c.CardIn).WillCascadeOnDelete(false); 
            HasRequired(a => a.Out).WithMany(b => b.OutOperations).HasForeignKey(c => c.CardOut).WillCascadeOnDelete(false); 
        }

    }
}
