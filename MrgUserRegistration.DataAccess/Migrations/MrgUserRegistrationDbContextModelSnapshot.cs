﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MrgUserRegistration.DataAccess.EntityFramework;

namespace MrgUserRegistration.DataAccess.Migrations
{
    [DbContext(typeof(MrgUserRegistrationDbContext))]
    partial class MrgUserRegistrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrgUserRegistration.DataAccess.EntityFramework.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InlineAddress")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MrgUserRegistration.DataAccess.EntityFramework.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<Guid>("UniqueFieldsId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UniqueFieldsId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MrgUserRegistration.DataAccess.EntityFramework.Entities.UniqueFields", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FavoriteFootballTeam");

                    b.Property<string>("PersonalNumber");

                    b.HasKey("Id");

                    b.ToTable("UniqueFields");
                });

            modelBuilder.Entity("MrgUserRegistration.DataAccess.EntityFramework.Entities.Customer", b =>
                {
                    b.HasOne("MrgUserRegistration.DataAccess.EntityFramework.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MrgUserRegistration.DataAccess.EntityFramework.Entities.UniqueFields", "UniqueFields")
                        .WithMany()
                        .HasForeignKey("UniqueFieldsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
