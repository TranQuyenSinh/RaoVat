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

        public int AuthorId { get; set; }
        public Customer Author { get; set; }

        public string Description { get; set; }

        // 0 - cũ, 1 - mới
        public bool Status { get; set; }

        [StringLength(255)]
        public string Color { get; set; }

        [StringLength(255)]
        public string Origin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime ExpireAt { get; set; } = DateTime.Now.AddDays(10);

        public int? AprovedUserId { get; set; }
        public User? ApovedUser { get; set; }

        public DateTime? AprovedAt { get; set; }

        public byte AprovedStatus { get; set; } = 0;

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Customer>? FavoredCustomers { get; set; }
        public virtual ICollection<AdImage>? Images { get; set; }

    }
}