using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrailerCheck.Data;

namespace TrailerCheck.Migrations
{
    [DbContext(typeof(TrailerCheckContext))]
    [Migration("20170803204314_TrailerDisplayNames")]
    partial class TrailerDisplayNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrailerCheck.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("TrailerCheck.Models.Registration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OwnerID");

                    b.Property<int>("TrailerID");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("TrailerID");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("TrailerCheck.Models.Trailer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ProductGroup");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("YearOfManufacture");

                    b.HasKey("ID");

                    b.ToTable("Trailer");
                });

            modelBuilder.Entity("TrailerCheck.Models.Registration", b =>
                {
                    b.HasOne("TrailerCheck.Models.Owner", "Owner")
                        .WithMany("Registrations")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrailerCheck.Models.Trailer", "Trailer")
                        .WithMany("Registrations")
                        .HasForeignKey("TrailerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
