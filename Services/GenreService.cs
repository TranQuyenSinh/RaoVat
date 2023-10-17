using App.Data;
using App.Models;
using App.Utils;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class GenreService
{
    public class GenreOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public int? ParentId { get; set; }
        public ICollection<GenreOutput> ChildGenres { get; set; } = new List<GenreOutput>();

        public GenreOutput(Genre genre)
        {
            Id = genre.Id;
            Title = genre.Title;
            Description = genre.Description;
            Slug = genre.Slug;
            Image = AppPath.GenerateImagePath(AppPath.GENRE_IMAGE, genre.Image);
            ParentId = genre.ParentId;
            ChildGenres = GetChildrenGenres(genre.ChildrenGenres);
        }
    }

    private readonly AppDbContext _context;
    public GenreService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<GenreOutput> GetAllGenres()
    {
        var genres = _context.Genres
        .Where(x => x.ParentId == null)
        .Include(x => x.ChildrenGenres)
        .Select(genre => new GenreOutput(genre))
        .ToList();
        return genres;
    }

    // không lấy childs
    public ICollection<GenreOutput> RootGenres()
    {
        var genres = _context.Genres.Where(x => x.ParentId == null).ToList();
        return genres.Select(genre => new GenreOutput(genre)).ToList();
    }


    // lấy childs
    public GenreOutput GetGenreBySlug(string slug)
    {
        var genre = _context.Genres.Where(x => x.Slug == slug).Include(x => x.ChildrenGenres).FirstOrDefault();
        if (genre != null)
        {
            return new GenreOutput(genre);
        }
        return null;
    }

    public static ICollection<GenreOutput> GetChildrenGenres(ICollection<Genre> genres)
    {
        if (genres == null) return null;

        var childs = genres.Select(genre => new GenreOutput(genre)).ToList();
        return childs;
    }

}