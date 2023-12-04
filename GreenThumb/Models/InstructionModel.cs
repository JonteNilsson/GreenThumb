using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        public int Id { get; set; }
        public string Instruction { get; set; } = null!;

        public PlantModel Plants { get; set; } = null!;
    }
}
