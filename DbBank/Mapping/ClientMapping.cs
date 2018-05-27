using BankData.Models;
using System.Data.Entity.ModelConfiguration;

namespace BankDb.Mapping
{
    public class ClientMapping: EntityTypeConfiguration<Client>
    {
        public ClientMapping()
        {
            ToTable("Clients", "dbo");
            HasKey(o => o.ClientID);

            Property(c => c.ClientID).HasColumnName("ClientID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(c => c.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(c => c.LastName).HasColumnName("LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(c => c.Birthday).HasColumnName("Birthday").HasColumnType("date").IsOptional();
            Property(c => c.Phone).HasColumnName("Phone").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(c => c.SSN).HasColumnName("SSN").HasColumnType("char").HasMaxLength(10).IsOptional();

            #region Address

            Property(c => c.Address.Country).HasColumnName("Country").HasColumnType("varchar").HasMaxLength(20).IsOptional();
            Property(c => c.Address.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(20).IsOptional();
            Property(c => c.Address.TheAddress).HasColumnName("TheAddress").HasColumnType("varchar").HasMaxLength(20).IsOptional();
            Property(c => c.Address.State).HasColumnName("State").HasColumnType("varchar").HasMaxLength(20).IsOptional();

            #endregion
        }
    }
}
