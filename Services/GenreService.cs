using App.Data;
using App.Models;
using App.Utils;

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
    }

    private readonly AppDbContext _context;
    public GenreService(AppDbContext context)
    {
        _context = context;
    }

    // không lấy childs
    public ICollection<GenreOutput> RootGenres()
    {
        var genres = _context.Genres.Where(x => x.ParentId == null).ToList();
        return genres.Select(x => new GenreOutput()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Image = CombineImagePath(x.Image),
            Slug = x.Slug,
        }).ToList();
    }


    // lấy childs
    public GenreOutput GetGenreBySlug(string slug)
    {
        var genre = _context.Genres.Where(x => x.Slug == slug).FirstOrDefault();
        if (genre != null)
        {
            return new GenreOutput()
            {
                Id = genre.Id,
                Title = genre.Title,
                Description = genre.Description,
                Image = CombineImagePath(genre.Image),
                Slug = genre.Slug,
                ChildGenres = GetChildrenGenres(genre.Id)
            };
        }
        return null;
    }

    public ICollection<GenreOutput> GetChildrenGenres(int id)
    {
        var childs = _context.Genres
        .Where(x => x.ParentId == id)
        .Select(x => new GenreOutput()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Image = CombineImagePath(x.Image),
            Slug = x.Slug,
        })
        .ToList();
        return childs;
    }

    public static string CombineImagePath(string image)
    {
        return image is not null ?
        Path.Combine(AppPath.GENRE_IMAGE_PATH, image) :
        null;
    }
}