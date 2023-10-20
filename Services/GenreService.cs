using App.Data;
using App.Models;
using App.ResponseModels;
using App.Utils;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class GenreService
{
    private readonly AppDbContext _context;
    public GenreService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<GenreModel> GetAllGenres()
    {
        var genres = _context.Genres
        .Where(x => x.ParentId == null)
        .Include(x => x.ChildrenGenres)
        .Select(genre => new GenreModel(genre))
        .ToList();
        return genres;
    }

    // không lấy childs
    public ICollection<GenreModel> RootGenres()
    {
        var genres = _context.Genres.Where(x => x.ParentId == null).ToList();
        return genres.Select(genre => new GenreModel(genre)).ToList();
    }


    // lấy childs
    public GenreModel GetGenreBySlug(string slug)
    {
        var genre = _context.Genres.Where(x => x.Slug == slug).Include(x => x.ChildrenGenres).FirstOrDefault();
        if (genre != null)
        {
            return new GenreModel(genre);
        }
        return null;
    }



}