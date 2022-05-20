using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPIPractise.model;

#nullable disable

namespace WebAPIPractise.Context
{
    public partial class FOODSTANBICContext : DbContext
    {
        public FOODSTANBICContext()
        {
        }

        public FOODSTANBICContext(DbContextOptions<FOODSTANBICContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["CompanyConnStr"].ConnectionString);                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department_name");

                entity.Property(e => e.FloorNumber).HasColumnName("floor_number");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Pincode).HasColumnName("PINCode");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("item_id");

                entity.Property(e => e.ItemCategoryId).HasColumnName("item_category_id");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("money")
                    .HasColumnName("item_price");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_item_item_category1");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_item_supply");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("item_category");

                entity.Property(e => e.ItemcategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("itemcategory_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ItemcategoryType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("itemcategory_type");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasColumnName("order_time");

                entity.Property(e => e.OrdereditemId).HasColumnName("ordereditem_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TimeCancelled)
                    .HasColumnType("datetime")
                    .HasColumnName("time_cancelled");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("time_created");

                entity.Property(e => e.TotalBill)
                    .HasColumnType("money")
                    .HasColumnName("total_bill");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Ordereditem)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrdereditemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_ordered_items");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_users");
            });

            modelBuilder.Entity<OrderedItem>(entity =>
            {
                entity.ToTable("ordered_items");

                entity.Property(e => e.OrdereditemId)
                    .ValueGeneratedNever()
                    .HasColumnName("ordereditem_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.OrdereditemAmount)
                    .HasColumnType("money")
                    .HasColumnName("ordereditem_amount");

                entity.Property(e => e.OrdereditemQuantity).HasColumnName("ordereditem_quantity");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("time_created");

                entity.Property(e => e.TimeUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("time_updated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ordered_items_item");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.Property(e => e.StockId)
                    .ValueGeneratedNever()
                    .HasColumnName("stock_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("supply");

                entity.Property(e => e.SupplyId)
                    .ValueGeneratedNever()
                    .HasColumnName("supply_id");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.Property(e => e.SuppliedQuantity).HasColumnName("supplied_quantity");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supply_stock");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.TimeCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("time_created");

                entity.Property(e => e.TimeDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("time_deleted");

                entity.Property(e => e.TimeUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("time_updated");

                entity.Property(e => e.UserCategoryId).HasColumnName("user_category_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_department");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_user_category");
            });

            modelBuilder.Entity<UserCategory>(entity =>
            {
                entity.ToTable("user_category");

                entity.Property(e => e.UsercategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("usercategory_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UsercategoryDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usercategory_description");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCategories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_category_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
