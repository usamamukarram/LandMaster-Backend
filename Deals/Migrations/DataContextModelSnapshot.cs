﻿// <auto-generated />
using Deals.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deals.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Deals.Models.Buyyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlotSizeId")
                        .HasColumnType("int");

                    b.Property<int>("SocietyBlocksBlockId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlotSizeId");

                    b.HasIndex("SocietyBlocksBlockId");

                    b.HasIndex("UserId");

                    b.ToTable("Buyyers");
                });

            modelBuilder.Entity("Deals.Models.PlotSize", b =>
                {
                    b.Property<int>("PlotSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlotSizeId"));

                    b.Property<string>("PlotSizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("PlotSizeId");

                    b.ToTable("PlotSizes");
                });

            modelBuilder.Entity("Deals.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Deals.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Demand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlotSizeId")
                        .HasColumnType("int");

                    b.Property<string>("Plot_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SocietyBlocksBlockId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlotSizeId");

                    b.HasIndex("SocietyBlocksBlockId");

                    b.HasIndex("UserId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("Deals.Models.Society", b =>
                {
                    b.Property<int>("SocietyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocietyId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("SocietyId");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("Deals.Models.SocietyBlocks", b =>
                {
                    b.Property<int>("BlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlockId"));

                    b.Property<bool>("BlockStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SocietyId")
                        .HasColumnType("int");

                    b.HasKey("BlockId");

                    b.HasIndex("SocietyId");

                    b.ToTable("societyBlocks");
                });

            modelBuilder.Entity("Deals.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verifystatus")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Deals.Models.Buyyer", b =>
                {
                    b.HasOne("Deals.Models.PlotSize", "PlotSize")
                        .WithMany()
                        .HasForeignKey("PlotSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deals.Models.SocietyBlocks", "SocietyBlocks")
                        .WithMany()
                        .HasForeignKey("SocietyBlocksBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deals.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlotSize");

                    b.Navigation("SocietyBlocks");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Deals.Models.Seller", b =>
                {
                    b.HasOne("Deals.Models.PlotSize", "PlotSize")
                        .WithMany()
                        .HasForeignKey("PlotSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deals.Models.SocietyBlocks", "SocietyBlocks")
                        .WithMany()
                        .HasForeignKey("SocietyBlocksBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deals.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlotSize");

                    b.Navigation("SocietyBlocks");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Deals.Models.SocietyBlocks", b =>
                {
                    b.HasOne("Deals.Models.Society", "society")
                        .WithMany()
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("society");
                });

            modelBuilder.Entity("Deals.Models.User", b =>
                {
                    b.HasOne("Deals.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
