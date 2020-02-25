﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleAssetManagement.Data;

namespace SimpleAssetManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.AuditLog", b =>
                {
                    b.Property<Guid>("Log_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Change")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Log_Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.Location", b =>
                {
                    b.Property<Guid>("Location_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location_Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                            Location_Name = "R&D"
                        },
                        new
                        {
                            Location_Id = new Guid("696a03e9-ae8d-46a5-918f-2e4c19cecfd3"),
                            Location_Name = "LAB"
                        });
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.Manufacture", b =>
                {
                    b.Property<Guid>("Manufacture_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Manufacture_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Manufacture_Id");

                    b.ToTable("Manufactures");

                    b.HasData(
                        new
                        {
                            Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                            Manufacture_Name = "RAININ"
                        },
                        new
                        {
                            Manufacture_Id = new Guid("33e11f97-1705-466f-8f9d-9773d33aed8f"),
                            Manufacture_Name = "METTLER TOLEDO"
                        });
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.Pippette", b =>
                {
                    b.Property<Guid>("Pippette_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Location_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Manufacture_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Pippette_User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsageFrequency")
                        .HasColumnType("int");

                    b.HasKey("Pippette_Id");

                    b.HasIndex("Location_Id");

                    b.HasIndex("Manufacture_Id");

                    b.HasIndex("Pippette_User_Id");

                    b.ToTable("Pippettes");

                    b.HasData(
                        new
                        {
                            Pippette_Id = new Guid("eb68664c-6205-4d3f-8bfa-9f013950d4a2"),
                            Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                            Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                            ModelName = "P2020",
                            Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                            SerialNumber = "P2020-FEB",
                            UsageFrequency = 10
                        },
                        new
                        {
                            Pippette_Id = new Guid("0899f922-885a-4430-bf49-12d298a34dfb"),
                            Location_Id = new Guid("696a03e9-ae8d-46a5-918f-2e4c19cecfd3"),
                            Manufacture_Id = new Guid("33e11f97-1705-466f-8f9d-9773d33aed8f"),
                            ModelName = "L2020",
                            Pippette_User_Id = new Guid("293d98bb-420b-4416-b5f0-7f6647e4548f"),
                            SerialNumber = "L2020-MAR",
                            UsageFrequency = 20
                        },
                        new
                        {
                            Pippette_Id = new Guid("c5b3bd62-3e24-441d-a8d9-72cf23ddbf9c"),
                            Location_Id = new Guid("696a03e9-ae8d-46a5-918f-2e4c19cecfd3"),
                            Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                            ModelName = "P2019",
                            Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                            SerialNumber = "P2019-MAR",
                            UsageFrequency = 510
                        },
                        new
                        {
                            Pippette_Id = new Guid("d9c29b6e-bf6f-4e59-a365-85f3bfeade0e"),
                            Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                            Manufacture_Id = new Guid("33e11f97-1705-466f-8f9d-9773d33aed8f"),
                            ModelName = "L2019",
                            Pippette_User_Id = new Guid("293d98bb-420b-4416-b5f0-7f6647e4548f"),
                            SerialNumber = "L2019-FEB",
                            UsageFrequency = 320
                        });
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.PippetteUser", b =>
                {
                    b.Property<Guid>("Pippette_User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pippette_User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pippette_User_Id");

                    b.ToTable("PippetteUsers");

                    b.HasData(
                        new
                        {
                            Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                            Pippette_User_Name = "Alex"
                        },
                        new
                        {
                            Pippette_User_Id = new Guid("293d98bb-420b-4416-b5f0-7f6647e4548f"),
                            Pippette_User_Name = "Joe"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleAssetManagement.Data.Pippette", b =>
                {
                    b.HasOne("SimpleAssetManagement.Data.Location", "Location")
                        .WithMany("Pippette")
                        .HasForeignKey("Location_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAssetManagement.Data.Manufacture", "Manufacture")
                        .WithMany("Pippette")
                        .HasForeignKey("Manufacture_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAssetManagement.Data.PippetteUser", "PippetteUser")
                        .WithMany("Pippette")
                        .HasForeignKey("Pippette_User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
