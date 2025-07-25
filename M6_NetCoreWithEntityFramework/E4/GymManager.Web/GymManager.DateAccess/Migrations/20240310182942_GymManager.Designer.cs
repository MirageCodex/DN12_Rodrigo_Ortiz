﻿// <auto-generated />
using System;
using GymManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManager.DataAccess.Migrations
{
    [DbContext(typeof(GymManagerContext))]
    [Migration("20240310182942_GymManager")]
    partial class GymManager
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.GymManager.Core.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idcities");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("cityname");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.EquipmentTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idequipmenttypes");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("equipmentname");

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idinventory");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MesureId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idmembers");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("cities_idcities");

                    b.Property<string>("MemberEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("memberemail");

                    b.Property<DateTime>("MemberEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("member_end");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("membername");

                    b.Property<string>("MemberPhone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("memberphone");

                    b.Property<DateTime>("MemberStart")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("member_start");

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameMembership")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.MesureTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idmesuretypes");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("MesureTypes");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.ProductTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idproducttypes");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("productcost");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("productdescription");

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("producttypename");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idsales");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cuantity")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("MesureTypesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SalesDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("salesdate");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("MesureTypesId");

                    b.HasIndex("ProductTypesId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Inventory", b =>
                {
                    b.HasOne("DataAccess.GymManager.Core.MesureTypes", "Mesure")
                        .WithMany("Inventories")
                        .HasForeignKey("MesureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.GymManager.Core.ProductTypes", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesure");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Member", b =>
                {
                    b.HasOne("DataAccess.GymManager.Core.City", "City")
                        .WithMany("Members")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.GymManager.Core.MembershipType", "MembershipType")
                        .WithMany("Members")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Sales", b =>
                {
                    b.HasOne("DataAccess.GymManager.Core.Inventory", "Inventory")
                        .WithMany("Sales")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.GymManager.Core.MesureTypes", "MesureTypes")
                        .WithMany("Sales")
                        .HasForeignKey("MesureTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.GymManager.Core.ProductTypes", "ProductTypes")
                        .WithMany("Sales")
                        .HasForeignKey("ProductTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("MesureTypes");

                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.City", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.Inventory", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.MembershipType", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.MesureTypes", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DataAccess.GymManager.Core.ProductTypes", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
