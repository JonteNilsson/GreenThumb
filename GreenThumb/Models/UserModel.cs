using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        [EncryptColumn]
        public string Password { get; set; } = null!;

        public GardenModel? Garden { get; set; }
    }
}
