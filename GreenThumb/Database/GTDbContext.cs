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
                Name = "Rose",
                Id = 1,
            }, new PlantModel
            {
                Name = "Tulip",
                Id = 2
            }, new PlantModel
            {
                Name = "Daisy",
                Id = 3
            }, new PlantModel
            {
                Name = "Sunflower",
                Id = 4
            }, new PlantModel
            {
                Name = "Lily",
                Id = 5,
            }, new PlantModel
            {
                Name = "Orchid",
                Id = 6,
            }, new PlantModel
            {
                Name = "Daffodil",
                Id = 7,
            }, new PlantModel
            {
                Name = "Peony",
                Id = 8,
            }, new PlantModel
            {
                Name = "Cactus",
                Id = 9,
            }, new PlantModel
            {
                Name = "Eucalyptus",
                Id = 10,
            }, new PlantModel
            {
                Name = "Lavender",
                Id = 11,
            }, new PlantModel
            {
                Name = "Marigold",
                Id = 12,
            });

            modelBuilder.Entity<InstructionModel>().HasData(new InstructionModel()
            {
                Id = 1,
                Instruction = "Keep soil consistently moist",
                PlantId = 1

            }, new InstructionModel()
            {
                Id = 2,
                Instruction = "Water moderately, let soil dry between.",
                PlantId = 2
            }, new InstructionModel()
            {
                Id = 3,
                Instruction = "Water when top inch is dry.",
                PlantId = 3
            }, new InstructionModel()
            {
                Id = 4,
                Instruction = "Water deeply and consistently.",
                PlantId = 4
            }, new InstructionModel()
            {
                Id = 5,
                Instruction = "Keep soil consistently moist.",
                PlantId = 5
            }, new InstructionModel()
            {
                Id = 6,
                Instruction = "Water sparingly, let the medium dry.",
                PlantId = 6
            }, new InstructionModel()
            {
                Id = 7,
                Instruction = "Water moderately, let soil dry.",
                PlantId = 7
            }, new InstructionModel()
            {
                Id = 8,
                Instruction = "Water deeply when top inch is dry",
                PlantId = 8
            }, new InstructionModel()
            {
                Id = 9,
                Instruction = "Water sparingly, let soil dry out.",
                PlantId = 9
            }, new InstructionModel()
            {
                Id = 10,
                Instruction = "Water regularly when young, let soil dry.",
                PlantId = 10
            }, new InstructionModel()
            {
                Id = 11,
                Instruction = "Water sparingly, let soil dry.",
                PlantId = 11
            }, new InstructionModel()
            {
                Id = 12,
                Instruction = "Water sparingly, let soil dry.",
                PlantId = 12
            }, new InstructionModel()
            {
                Id = 13,
                Instruction = "Plant in well-drained soil, with sunlight.",
                PlantId = 1
            }, new InstructionModel()
            {
                Id = 14,
                Instruction = "Plant bulbs in fall, in well-drained soil.",
                PlantId = 2
            }, new InstructionModel()
            {
                Id = 15,
                Instruction = "Plant in spring, in sunny location.",
                PlantId = 3
            }, new InstructionModel()
            {
                Id = 16,
                Instruction = "Plant seeds in spring, in fertile soil.",
                PlantId = 4
            }, new InstructionModel()
            {
                Id = 17,
                Instruction = " Plant bulbs in spring, in partial shade.",
                PlantId = 5
            }, new InstructionModel()
            {
                Id = 18,
                Instruction = "Plant in orchid mix, with good drainage.",
                PlantId = 6
            }, new InstructionModel()
            {
                Id = 19,
                Instruction = "Plant bulbs in fall, in well-drained soil.",
                PlantId = 7
            }, new InstructionModel()
            {
                Id = 20,
                Instruction = "Plant in fertile, well-drained soil.",
                PlantId = 8
            }, new InstructionModel()
            {
                Id = 21,
                Instruction = "Plant in cactus mix, in full sunlight.",
                PlantId = 9
            }, new InstructionModel()
            {
                Id = 22,
                Instruction = " Plant in well-drained soil, in sunlight.",
                PlantId = 10
            }, new InstructionModel()
            {
                Id = 23,
                Instruction = "Plant in well-drained soil, in sunlight.",
                PlantId = 11
            }, new InstructionModel()
            {
                Id = 24,
                Instruction = "Plant in well-drained soil, in sunlight.",
                PlantId = 12
            }, new InstructionModel()
            {
                Id = 25,
                Instruction = "Prune in late winter to encourage new growth.",
                PlantId = 1
            }, new InstructionModel()
            {
                Id = 26,
                Instruction = "Mulch in winter for added insulation.",
                PlantId = 2
            }, new InstructionModel()
            {
                Id = 27,
                Instruction = "Deadhead spent blooms for prolonged flowering.",
                PlantId = 3
            }, new InstructionModel()
            {
                Id = 28,
                Instruction = "Provide support for tall varieties.",
                PlantId = 4
            }, new InstructionModel()
            {
                Id = 29,
                Instruction = "Apply a balanced fertilizer in spring.",
                PlantId = 5
            }, new InstructionModel()
            {
                Id = 30,
                Instruction = "Provide indirect sunlight for optimal growth.",
                PlantId = 6
            }, new InstructionModel()
            {
                Id = 31,
                Instruction = "Allow foliage to yellow before removing.",
                PlantId = 7
            }, new InstructionModel()
            {
                Id = 32,
                Instruction = "Stake heavy blooms to prevent drooping.",
                PlantId = 8
            }, new InstructionModel()
            {
                Id = 33,
                Instruction = "Protect from frost during winter.",
                PlantId = 9
            }, new InstructionModel()
            {
                Id = 34,
                Instruction = "Prune for bushier growth.",
                PlantId = 10
            }, new InstructionModel()
            {
                Id = 35,
                Instruction = "Prune after flowering to maintain shape.",
                PlantId = 11
            }, new InstructionModel()
            {
                Id = 36,
                Instruction = "Pinch back young plants for bushier growth.",
                PlantId = 12
            });

        }

    }
}

