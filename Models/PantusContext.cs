using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pantus.Models;

public partial class PantusContext : DbContext
{
    public PantusContext()
    {
    }

    public PantusContext(DbContextOptions<PantusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogCategory> TbBlogCategories { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbEvent> TbEvents { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbMenuCategory> TbMenuCategories { get; set; }

    public virtual DbSet<TbMenuItem> TbMenuItems { get; set; }

    public virtual DbSet<TbMenuReview> TbMenuReviews { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbOrderStatus> TbOrderStatuses { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbService> TbServices { get; set; }

    public virtual DbSet<TbTable> TbTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__tb_Accou__349DA5A6C2AA9C29");

            entity.ToTable("tb_Account");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TbAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__tb_Accoun__RoleI__398D8EEE");
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__tb_Blog__54379E308C17B235");

            entity.ToTable("tb_Blog");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(500);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__tb_Blog__Account__571DF1D5");

            entity.HasOne(d => d.Category).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__tb_Blog__Categor__5629CD9C");
        });

        modelBuilder.Entity<TbBlogCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tb_BlogC__19093A0BA392A7DE");

            entity.ToTable("tb_BlogCategory");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__tb_BlogC__C3B4DFCAC7BB0E04");

            entity.ToTable("tb_BlogComment");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Blog).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK__tb_BlogCo__BlogI__59FA5E80");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__tb_Conta__5C66259B18CAE438");

            entity.ToTable("tb_Contact");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tb_Custo__A4AE64D8157E893F");

            entity.ToTable("tb_Customer");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870AC7E140C");

            entity.ToTable("tb_Event");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Details).HasMaxLength(int.MaxValue);
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__tb_Invoi__D796AAB518B48FF7");

            entity.ToTable("tb_Invoice");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__tb_Invoic__Order__4F7CD00D");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.UrlPath).HasMaxLength(500);
        });

        modelBuilder.Entity<TbMenuCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tb_MenuC__19093A0B2306E548");

            entity.ToTable("tb_MenuCategory");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TbMenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("PK__tb_MenuI__8943F722EBC2D616");

            entity.ToTable("tb_MenuItem");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.Category).WithMany(p => p.TbMenuItems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__tb_MenuIt__Categ__403A8C7D");
        });

        modelBuilder.Entity<TbMenuReview>(entity =>
        {
            entity.HasKey(e => e.MenuReviewId).HasName("PK__tb_MenuR__2897E727EE43628A");

            entity.ToTable("tb_MenuReview");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.MenuItem).WithMany(p => p.TbMenuReviews)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_MenuRe__MenuI__76969D2E");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tb_Order__C3905BCFBB99CA0F");

            entity.ToTable("tb_Order");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasColumnName("Phone");
            entity.Property(e => e.Settable).HasColumnName("Settable");
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Message).HasMaxLength(250);
            

            entity.HasOne(d => d.Customer).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__tb_Order__Custom__46E78A0C");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__tb_Order__OrderS__48CFD27E");

            entity.HasOne(d => d.Table).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__tb_Order__TableI__47DBAE45");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__tb_Order__D3B9D36C895C521E");

            entity.ToTable("tb_OrderDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([Price]*[Quantity])", true)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.MenuItemId)
                .HasConstraintName("FK__tb_OrderD__MenuI__4CA06362");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__tb_OrderD__Order__4BAC3F29");
        });

        modelBuilder.Entity<TbOrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__tb_Order__BC674CA18A35ECC5");

            entity.ToTable("tb_OrderStatus");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tb_Role__8AFACE1ABAC2DFFD");

            entity.ToTable("tb_Role");

            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__tb_Servi__C51BB00A2076A3C1");

            entity.ToTable("tb_Services");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TbTable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__tb_Table__7D5F01EE9D57B3AE");

            entity.ToTable("tb_Table");

            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TableNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
