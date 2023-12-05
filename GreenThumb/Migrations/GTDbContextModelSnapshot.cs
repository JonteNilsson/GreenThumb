﻿// <auto-generated />
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GTDbContext))]
    partial class GTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GardenModelPlantModel", b =>
                {
                    b.Property<int>("GardensId")
                        .HasColumnType("int");

                    b.Property<int>("PlantsId")
                        .HasColumnType("int");

                    b.HasKey("GardensId", "PlantsId");

                    b.HasIndex("PlantsId");

                    b.ToTable("GardenModelPlantModel");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Gardens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Eden",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("instruction");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Instruction = "Water plant",
                            PlantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Instruction = "Water Plant",
                            PlantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Instruction = "Fertilize",
                            PlantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Instruction = "Remove weed",
                            PlantId = 3
                        },
                        new
                        {
                            Id = 5,
                            Instruction = "Replant",
                            PlantId = 5
                        },
                        new
                        {
                            Id = 6,
                            Instruction = "Add soil",
                            PlantId = 7
                        },
                        new
                        {
                            Id = 7,
                            Instruction = "Cut away weeds",
                            PlantId = 4
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sunflower"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lilly"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rose"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cactus"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bamboo"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Orchid"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Snake plant"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Eucalyptus"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "LWAdod+E1okcunZOFtuoeg==",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("GardenModelPlantModel", b =>
                {
                    b.HasOne("GreenThumb.Models.GardenModel", null)
                        .WithMany()
                        .HasForeignKey("GardensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumb.Models.PlantModel", null)
                        .WithMany()
                        .HasForeignKey("PlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.HasOne("GreenThumb.Models.UserModel", "User")
                        .WithOne("Garden")
                        .HasForeignKey("GreenThumb.Models.GardenModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Navigation("Garden");
                });
#pragma warning restore 612, 618
        }
    }
}
