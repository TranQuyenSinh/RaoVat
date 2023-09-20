using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string? Icon { get; set; }

        public string? Image { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Genre Parent { get; set; }

        public virtual ICollection<Genre>? ChildGenres { get; set; }

        public virtual ICollection<Customer>? Customers { get; set; }

        public virtual ICollection<Ad>? Ads { get; set; }
    }
}