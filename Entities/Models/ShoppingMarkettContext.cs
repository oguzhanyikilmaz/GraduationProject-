using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class ShoppingMarkettContext : DbContext
    {
        public ShoppingMarkettContext()
        {
        }

        public ShoppingMarkettContext(DbContextOptions<ShoppingMarkettContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketItem> BasketItem { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CreditCarts> CreditCarts { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-MIBNP62A\\SQLEXPRESS;Database=ShoppingMarkett;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__BasketIt__028856F42A164134");

                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetails_Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItem)
                    .HasForeignKey(d => d.BasketId)
                    .HasConstraintName("FK__BasketIte__Baske__2CF2ADDF");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BasketItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__BasketIte__Produ__2BFE89A6");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.SellBy)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalAmount).HasColumnType("money");
            });

            modelBuilder.Entity<CartDetails>(entity =>
            {
                entity.Property(e => e.CartDetailsId).HasColumnName("CartDetails_Id");

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartDetai__Cart___37A5467C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartDetai__Produ__36B12243");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__6DB38D6E1BFD2C07");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Countrie__8036CBAE7F60ED59");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.CountryName)
                    .HasColumnName("Country_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCarts>(entity =>
            {
                entity.HasKey(e => e.CartNumber)
                    .HasName("PK__CreditCa__05BE2CF65165187F");

                entity.Property(e => e.CartNumber).ValueGeneratedNever();

                entity.Property(e => e.CardBalance).HasColumnType("money");

                entity.Property(e => e.CartPassword).HasMaxLength(4);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DistrictId).HasColumnName("District_Id");

                entity.Property(e => e.CustomDisctName)
                    .HasColumnName("Custom_Disct_Name")
                    .HasMaxLength(60);

                entity.Property(e => e.DistrictName)
                    .HasColumnName("District_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvId).HasColumnName("Prov_Id");

                entity.HasOne(d => d.Prov)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.ProvId)
                    .HasConstraintName("FK__District__Prov_I__09DE7BCC");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetails_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__4C6B5938");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__4B7734FF");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF44CA3770");

                entity.Property(e => e.Email).HasMaxLength(55);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(25);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderNumber).HasMaxLength(25);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Province).HasMaxLength(25);

                entity.Property(e => e.TotalAmount).HasColumnType("money");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__9834FBBA1FCDBCEB");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__21B6055D");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasKey(e => e.ProvinceId)
                    .HasName("PK__Province__D445B66203317E3D");

                entity.Property(e => e.ProvinceId).HasColumnName("Province_Id");

                entity.Property(e => e.ContId).HasColumnName("Cont_Id");

                entity.Property(e => e.ProvName)
                    .HasColumnName("Prov_Name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cont)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.ContId)
                    .HasConstraintName("FK__Provinces__Cont___0519C6AF");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__UserRole__D80AB4BB0CBAE877");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C108B795B");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D105341367E606")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F28456164452B1")
                    .IsUnique();

                entity.Property(e => e.DistrictId).HasColumnName("District_Id");

                entity.Property(e => e.Email).HasMaxLength(55);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(25);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Users__District___1920BF5C");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__Role_Id__182C9B23");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
