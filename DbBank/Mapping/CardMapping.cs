using BankData.Models;
using System.Data.Entity.ModelConfiguration;

namespace BankDb.Mapping
{
    public class CardMapping: EntityTypeConfiguration<Card>
    {
        public CardMapping()
        {
            ToTable("Cards", "dbo");
            HasKey(c => c.CardID);

            Property(c => c.CardID).HasColumnName("CardID").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(16).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(c => c.ClientId).HasColumnName("ClientID").HasColumnType("int").IsRequired();
            Property(c => c.PinCode).HasColumnName("PinCode").HasColumnType("char").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(4);
            Property(c => c.Ballance).HasColumnName("Ballance").HasColumnType("money").IsRequired().HasPrecision(19, 4);

            // Foreign keys
            HasRequired(a => a.Client).WithMany(b => b.Cards).HasForeignKey(c => c.ClientId).WillCascadeOnDelete(false);
        }
    }
}
