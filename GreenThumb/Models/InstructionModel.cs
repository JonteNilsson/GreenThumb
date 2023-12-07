using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("instruction")]
        public string Instruction { get; set; } = null!;
        [Column("plant_id")]
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;

        public InstructionModel(string instruction)
        {
            Instruction = instruction;
        }

        public InstructionModel()
        {

        }
    }
}
