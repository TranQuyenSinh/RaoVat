using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class User_Genre_Favorite
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int GenreId { get; set; }
}