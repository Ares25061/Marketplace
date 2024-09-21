﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class MarketpalceContext : DbContext
    {
        public MarketpalceContext()
        {
        }

        public MarketpalceContext(DbContextOptions<MarketpalceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<AttributeValue> AttributeValues { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryAttribute> CategoryAttributes { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<ChatParticipant> ChatParticipants { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<FilePermission> FilePermissions { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentUser> PaymentUsers { get; set; } = null!;
        public virtual DbSet<PriceHistory> PriceHistories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SearchHistory> SearchHistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDiscount> UserDiscounts { get; set; } = null!;
        public virtual DbSet<UserFile> UserFiles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Addresses_Users");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.Property(e => e.AttributeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.HasKey(e => e.ValueId)
                    .HasName("PK__Attribut__93364E4866D6BFEF");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValueName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeValues_Attributes");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "UQ__Categori__8517B2E0C8A1C34F")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_CategoryAttributes_Attributes");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryAttributes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CategoryAttributes_Categories");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatParticipant>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatParticipants)
                    .HasForeignKey(d => d.ChatId)
                    .HasConstraintName("FK_ChatParticipants_Chats");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatParticipants)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ChatParticipants_Users");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasIndex(e => e.DiscountCode, "UQ__Discount__A1120AF5074BDBB6")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FilePermission>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PermissionLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FilePermissions)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_FilePermissions_Files");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FilePermissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FilePermissions_Users");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.MessageContent).IsUnicode(false);

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatId)
                    .HasConstraintName("FK_Messages_Chats");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Messages_Users");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NotificationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notifications_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Pending')");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Card_number");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV")
                    .IsFixedLength();

                entity.Property(e => e.ExpressionDate)
                    .HasColumnType("date")
                    .HasColumnName("Expression_date");
            });

            modelBuilder.Entity<PaymentUser>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payment___9B556A58C98966D6");

                entity.ToTable("Payment_Users");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentID");

                entity.Property(e => e.IsActive).HasColumnName("Is_active");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Payment)
                    .WithOne(p => p.PaymentUser)
                    .HasForeignKey<PaymentUser>(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Users_Payment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Payment_Users_Users");
            });

            modelBuilder.Entity<PriceHistory>(entity =>
            {
                entity.ToTable("PriceHistory");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceHistories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PriceHistory_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK_Products_Users");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_ProductAttributes_Attributes");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductAttributes_Products");

                entity.HasOne(d => d.Value)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ValueId)
                    .HasConstraintName("FK_ProductAttributes_AttributeValues");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Reviews_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616057DB70C1")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.ToTable("SearchHistory");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.SearchDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SearchTerm)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SearchHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SearchHistory_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4F8A01CAB")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F87D305E")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDiscount>(entity =>
            {
                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.UserDiscounts)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_UserDiscounts_Discounts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDiscounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDiscounts_Users");
            });

            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.UserFiles)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_UserFiles_Files");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserFiles_Users");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
