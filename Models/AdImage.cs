using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("AdImage")]
    public class AdImage
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string FileName { get; set; }

        public int AdId { get; set; }

    }
}