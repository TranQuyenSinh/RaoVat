using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class AdGenre
{
    [Key]
    public int Id { get; set; }

    public int AdId { get; set; }
    public Ad Ad { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}