﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TKC_MDS.Data;

#nullable disable

namespace TKC_MDS.Migrations
{
    [DbContext(typeof(MSD_Context))]
    [Migration("20231011044039_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TKC_MDS.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TKC_MDS.Data.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("TKC_MDS.Models.AdjustOrderRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdjustOrderRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc978a17-fdfd-47e5-8a99-00f615dba482"),
                            Description = "View",
                            Name = "ViewAdjustOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9961)
                        },
                        new
                        {
                            Id = new Guid("42c066b9-1116-43d8-9528-21e62fecbf8d"),
                            Description = "Create",
                            Name = "CreateAdjustOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9964)
                        },
                        new
                        {
                            Id = new Guid("3031fd81-fd07-4870-8a41-10da124e2de7"),
                            Description = "Edit",
                            Name = "EditAdjustOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9965)
                        },
                        new
                        {
                            Id = new Guid("09e8a25d-d6ea-4510-a7d8-820e985711ad"),
                            Description = "Delete",
                            Name = "DeleteAdjustOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9966)
                        });
                });

            modelBuilder.Entity("TKC_MDS.Models.ClaimRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AccessRolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAllow")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClaimRoles");
                });

            modelBuilder.Entity("TKC_MDS.Models.DataTypeRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DataTypeRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49c409df-3739-450e-b36a-b90a5f25d783"),
                            Description = "View",
                            Name = "ViewDataType",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9986)
                        },
                        new
                        {
                            Id = new Guid("1b4963e5-e680-43c8-aab9-dfe4c42f1b24"),
                            Description = "Create",
                            Name = "CreateDataType",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9990)
                        },
                        new
                        {
                            Id = new Guid("f117536f-8d9a-4547-a581-447f8b9cfb7f"),
                            Description = "Edit",
                            Name = "EditDataType",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9991)
                        },
                        new
                        {
                            Id = new Guid("6ac9f5ed-130b-4a42-ac93-ef8f780ca052"),
                            Description = "Delete",
                            Name = "DeleteDataType",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9992)
                        });
                });

            modelBuilder.Entity("TKC_MDS.Models.ManageUserRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ManageUserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe68f89d-0197-4456-8c99-8e686b1e9c57"),
                            Description = "View",
                            Name = "ViewUser",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(34)
                        },
                        new
                        {
                            Id = new Guid("dc45e197-8a5d-4297-ab80-0d3f7f676ae7"),
                            Description = "Create",
                            Name = "CreateUser",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(37)
                        },
                        new
                        {
                            Id = new Guid("37a70ebf-1910-4011-8a62-82ee133027db"),
                            Description = "Edit",
                            Name = "EditUser",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(38)
                        },
                        new
                        {
                            Id = new Guid("f1737f3a-0c16-432f-b1c3-bf116dece7f6"),
                            Description = "Delete",
                            Name = "DeleteUser",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(39)
                        });
                });

            modelBuilder.Entity("TKC_MDS.Models.ReportRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ReportRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5e2b8cb3-06c5-49ad-a6a1-be82bfa4d32d"),
                            Description = "View",
                            Name = "ViewReport",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(13)
                        },
                        new
                        {
                            Id = new Guid("5e916eb6-ad22-47b3-8726-669d4450f12a"),
                            Description = "Create",
                            Name = "CreateReport",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(16)
                        },
                        new
                        {
                            Id = new Guid("0b70442f-6512-45f6-9375-65556b875a20"),
                            Description = "Edit",
                            Name = "EditReport",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(17)
                        },
                        new
                        {
                            Id = new Guid("0ed7ae7f-a621-459e-805d-5d2823b57208"),
                            Description = "Delete",
                            Name = "DeleteReport",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(18)
                        });
                });

            modelBuilder.Entity("TKC_MDS.Models.SaveOrderRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SaveOrderRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8cd7052-9c28-4da3-a14a-a6aa0765b334"),
                            Description = "View",
                            Name = "ViewOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9886)
                        },
                        new
                        {
                            Id = new Guid("dbceaee8-7e6b-44fe-8fdd-0924da63144d"),
                            Description = "Create",
                            Name = "CreateOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9891)
                        },
                        new
                        {
                            Id = new Guid("40ab784e-29e9-477a-abeb-c138f0b96825"),
                            Description = "Edit",
                            Name = "EditOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9892)
                        },
                        new
                        {
                            Id = new Guid("d4456a1d-6b6d-4d4b-86d3-8ae16726e612"),
                            Description = "Delete",
                            Name = "DeleteOrder",
                            UpdateDate = new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9893)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TKC_MDS.Data.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TKC_MDS.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TKC_MDS.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TKC_MDS.Data.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKC_MDS.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TKC_MDS.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
