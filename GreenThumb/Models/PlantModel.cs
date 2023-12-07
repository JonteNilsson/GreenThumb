using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        public List<InstructionModel> Instructions { get; set; } = new();
        public List<GardenModel> Gardens { get; set; } = new();

        public PlantModel(string name, List<InstructionModel> instructions)
        {
            Name = name;
            Instructions = instructions;
        }
        public PlantModel()
        {

        }

    }
}
