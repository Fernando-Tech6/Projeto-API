// <auto-generated />
using Loja.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210604114719_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Loja.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasMaxLength(6);

                    b.Property<string>("PublicArea")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Loja.Domain.Entities.BuyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Buys");
                });

            modelBuilder.Entity("Loja.Domain.Entities.ClientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AdressId")
                        .IsUnique();

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Loja.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<bool>("InStock")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Unity")
                        .IsRequired()
                        .HasColumnType("varchar(8) CHARACTER SET utf8mb4")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Loja.Domain.Entities.ProviderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AdressId")
                        .IsUnique();

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Loja.Domain.Entities.SaleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Delivered")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("StockId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Loja.Domain.Entities.StockEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BuyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuyId")
                        .IsUnique();

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Loja.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Loja.Domain.Entities.BuyEntity", b =>
                {
                    b.HasOne("Loja.Domain.Entities.ProductEntity", "ProductB")
                        .WithMany("ProdBuy")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("Loja.Domain.Entities.ProviderEntity", "ProviderBuy")
                        .WithMany("BuyPro")
                        .HasForeignKey("ProviderId")
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Entities.ClientEntity", b =>
                {
                    b.HasOne("Loja.Domain.Entities.AddressEntity", "AdressCl")
                        .WithOne("ClientAd")
                        .HasForeignKey("Loja.Domain.Entities.ClientEntity", "AdressId")
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Entities.ProviderEntity", b =>
                {
                    b.HasOne("Loja.Domain.Entities.AddressEntity", "AdressPr")
                        .WithOne("ProviderAd")
                        .HasForeignKey("Loja.Domain.Entities.ProviderEntity", "AdressId")
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Entities.SaleEntity", b =>
                {
                    b.HasOne("Loja.Domain.Entities.ClientEntity", "ClientSale")
                        .WithMany("SaleCl")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("Loja.Domain.Entities.StockEntity", "SaleSt")
                        .WithMany("SaleSt")
                        .HasForeignKey("StockId")
                        .IsRequired();
                });

            modelBuilder.Entity("Loja.Domain.Entities.StockEntity", b =>
                {
                    b.HasOne("Loja.Domain.Entities.BuyEntity", "BuySt")
                        .WithOne("StockBuy")
                        .HasForeignKey("Loja.Domain.Entities.StockEntity", "BuyId")
                        .IsRequired();

                    b.HasOne("Loja.Domain.Entities.ProductEntity", "ProductSt")
                        .WithOne("StockP")
                        .HasForeignKey("Loja.Domain.Entities.StockEntity", "ProductId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
