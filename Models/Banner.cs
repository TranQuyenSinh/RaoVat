using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class Banner
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string FileName { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public bool Display { get; set; } = true;
    public DateTime CreatedAt { get; set; }
}