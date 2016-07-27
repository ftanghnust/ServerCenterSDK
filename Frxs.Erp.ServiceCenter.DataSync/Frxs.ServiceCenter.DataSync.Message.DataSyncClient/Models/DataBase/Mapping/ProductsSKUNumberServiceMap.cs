using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models.Mapping
{
    public class ProductsSKUNumberServiceMap : EntityTypeConfiguration<ProductsSKUNumberService>
    {
        public ProductsSKUNumberServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.ID)
  .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductsSKUNumberService");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.States).HasColumnName("States");
        }
    }
}
