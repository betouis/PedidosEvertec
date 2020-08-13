namespace PediosEvertec.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelPedidos : DbContext
    {
        public ModelPedidos()
            : base("name=ModelPedidos")
        {
        }

        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<product> product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>()
                .Property(e => e.name_product)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);
        }
    }
}
