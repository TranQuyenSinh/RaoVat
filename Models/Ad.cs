using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Ad")]
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        // 0 - cũ, 1 - mới
        public bool Status { get; set; }

        [StringLength(255)]
        public string Color { get; set; }

        [StringLength(255)]
        public string Origin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime ExpireAt { get; set; } = DateTime.Now.AddDays(14);

        public int AuthorId { get; set; }
        public User Author { get; set; }

        /* ================ Aprove information ================ */
        public int? AprovedUserId { get; set; }
        public User? ApovedUser { get; set; }

        public DateTime? AprovedAt { get; set; }

        // 0: chưa kiểm duyệt, 1: đã kiểm duyệt, 2: đã từ chối
        public byte AprovedStatus { get; set; } = 0;
        public bool Display { get; set; } = true;

        public virtual ICollection<AdGenre> AdGenre { get; set; }
        public virtual ICollection<User_Ad_Favorite>? UserAd { get; set; }
        public virtual ICollection<AdImage>? Images { get; set; }

    }
}