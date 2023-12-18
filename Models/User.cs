using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        /* ================ Auth ================ */
        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        /* ================ Personal information ================ */

        [StringLength(255)]
        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        public string? Description { get; set; }

        public bool? Gender { get; set; }

        public bool IsLocked { get; set; } = false;

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public virtual ICollection<User>? Followers { get; set; }
        public virtual ICollection<User>? Followed { get; set; }

        public virtual ICollection<User_Ad_Favorite>? UserAd { get; set; }
        // Own ads
        public virtual ICollection<Ad>? OwnAds { get; set; }

    }
}