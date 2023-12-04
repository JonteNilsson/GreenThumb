﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class GardenModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        public List<PlantModel> Plants { get; set; } = new();
        [Column("user_id")]
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
    }
}
