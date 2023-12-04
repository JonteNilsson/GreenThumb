using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class GardenModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<PlantModel> Plants { get; set; } = new();
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
    }
}
