namespace App.Models;

public class User_Ad_Favorite
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int AdId { get; set; }
    public Ad Ad { get; set; }
}