using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb.Managers;
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
            _provider = new GenerateEncryptionProvider(KeyManager.GenerateEncryptionKey());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenTDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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





            });
        }

    }
}
