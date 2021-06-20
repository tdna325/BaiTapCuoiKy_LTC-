using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class TranDuyNhanContext : DbContext
    {
        public TranDuyNhanContext()
            : base("name=TranDuyNhanContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_ID);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);
        }
    }
}
