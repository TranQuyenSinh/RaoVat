using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        public string? Description { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public virtual ICollection<Genre>? FavorGenres { get; set; }
        public virtual ICollection<Ad>? FavorAds { get; set; }

        // Own ads
        public virtual ICollection<Ad>? Ads { get; set; }

    }
}