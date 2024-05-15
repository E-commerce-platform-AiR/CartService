using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CartService.Database.Entities;

namespace CartService.Database.Configuration
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.ToTable("cart_entity");

            builder.HasKey(x => x.Id)
                .HasName("PK_cart_entity");

            builder.Property(x => x.Id)
                .HasColumnName("cart_id");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id");

            builder.Property(x => x.ProductId)
                .HasColumnName("product_id");

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity");
        }
    }
}
