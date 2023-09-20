using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}