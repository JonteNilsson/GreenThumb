using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    public class GTDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;

        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<UserModel> Users { get; set; }


        public GTDbContext()
        {
            _provider = new GenerateEncryptionProvider("ThIsIsAsAfEKey$=");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenTDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Username)
                .IsUnique();


            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_provider);

            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 1,
                Username = "user",
                Password = "password"
            });

            modelBuilder.Entity<PlantModel>().HasData(new PlantModel
            {
                Name = "Sunflower",
                Id = 1,
            }, new PlantModel
            {
                Name = "Lilly",
                Id = 2
            }, new PlantModel
            {
                Name = "Rose",
                Id = 3
            }, new PlantModel
            {
                Name = "Cactus",
                Id = 4
            }, new PlantModel
            {
                Name = "Bamboo",
                Id = 5,
            }, new PlantModel
            {
                Name = "Orchid",
                Id = 6,
            }, new PlantModel
            {
                Name = "Snake plant",
                Id = 7,
            }, new PlantModel
            {
                Name = "Eucalyptus",
                Id = 8,
            });

            modelBuilder.Entity<InstructionModel>().HasData(new InstructionModel()
            {
                Id = 1,
                Instruction = "Water plant",
                PlantId = 1

            }, new InstructionModel()
            {
                Id = 2,
                Instruction = "Water Plant",
                PlantId = 2
            }, new InstructionModel()
            {
                Id = 3,
                Instruction = "Fertilize",
                PlantId = 1
            }, new InstructionModel()
            {
                Id = 4,
                Instruction = "Remove weed",
                PlantId = 3
            }, new InstructionModel()
            {
                Id = 5,
                Instruction = "Replant",
                PlantId = 5
            }, new InstructionModel()
            {
                Id = 6,
                Instruction = "Add soil",
                PlantId = 7
            }, new InstructionModel()
            {
                Id = 7,
                Instruction = "Cut away weeds",
                PlantId = 4
            });

            modelBuilder.Entity<GardenModel>().HasData(new GardenModel()
            {
                Id = 1,
                Name = "Eden",
                UserId = 1,
                Plants = new List<PlantModel>()
                {

                }
            });
        }

    }
}

