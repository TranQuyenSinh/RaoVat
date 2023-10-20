using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class GenreModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string Image { get; set; }
    public int? ParentId { get; set; }
    public ICollection<GenreModel> ChildGenres { get; set; } = new List<GenreModel>();

    public GenreModel(Genre genre)
    {
        Id = genre.Id;
        Title = genre.Title;
        Description = genre.Description;
        Slug = genre.Slug;
        Image = AppPath.GenerateImagePath(AppPath.GENRE_IMAGE, genre.Image);
        ParentId = genre.ParentId;
        ChildGenres = GetChildrenGenres(genre.ChildrenGenres);
    }

    public static ICollection<GenreModel> GetChildrenGenres(ICollection<Genre> genres)
    {
        if (genres == null) return null;

        var childs = genres.Select(genre => new GenreModel(genre)).ToList();
        return childs;
    }
}