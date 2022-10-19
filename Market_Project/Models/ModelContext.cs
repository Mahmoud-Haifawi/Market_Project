using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Market_Project.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category1> Category1s { get; set; }
        public virtual DbSet<CategoryStore> CategoryStores { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<Order1> Order1s { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        public virtual DbSet<Role1> Role1s { get; set; }
        public virtual DbSet<Store1> Store1s { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<User1> User1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH14_User269;PASSWORD=Ammal1960&&;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH14_USER269")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Category1>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("SYS_C00221501");

                entity.ToTable("CATEGORY1");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<CategoryStore>(entity =>
            {
                entity.HasKey(e => e.CategoryStore1)
                    .HasName("SYS_C00221519");

                entity.ToTable("CATEGORY_STORE");

                entity.Property(e => e.CategoryStore1)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_STORE");

                entity.Property(e => e.CatId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STORE_ID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.CategoryStores)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00221521");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CategoryStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00221520");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Address)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Freeshippinglimit)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("FREESHIPPINGLIMIT");

                entity.Property(e => e.Homeimg)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("HOMEIMG");

                entity.Property(e => e.Logoimg)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("LOGOIMG");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Supportworktime)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("SUPPORTWORKTIME");
            });

            modelBuilder.Entity<Order1>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("SYS_C00221534");

                entity.ToTable("ORDER1");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.Datee)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEE");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order1s)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00221535");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("SYS_C00221553");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Discount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("DISCOUNT");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Productdescription)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTDESCRIPTION");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTNAME");

                entity.Property(e => e.Propricse)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PROPRICSE");

                entity.Property(e => e.Prosale)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PROSALE");

                entity.Property(e => e.Quntitiy)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUNTITIY");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("SYS_C00221517");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("PRODUCT_ORDER");

                entity.Property(e => e.ProductOrderId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ORDER_ID");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Proid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PROID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("SYS_C00221541");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.Proid)
                    .HasConstraintName("SYS_C00221540");
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C00221502");

                entity.ToTable("ROLE1");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Roletype)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("ROLETYPE");
            });

            modelBuilder.Entity<Store1>(entity =>
            {
                entity.HasKey(e => e.Storeid)
                    .HasName("SYS_C00221509");

                entity.ToTable("STORE1");

                entity.Property(e => e.Storeid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STOREID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Namestore)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("NAMESTORE");

                entity.Property(e => e.Opentime)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("OPENTIME");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("SYS_C00221547");

                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.TestId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TEST_ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Publishdate)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PUBLISHDATE");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(222)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C00221548");
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C00221529");

                entity.ToTable("USER1");

                entity.HasIndex(e => e.Email, "SYS_C00221530")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.User1s)
                    .HasForeignKey(d => d.Homeid)
                    .HasConstraintName("SYS_C00221532");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User1s)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("SYS_C00221531");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
