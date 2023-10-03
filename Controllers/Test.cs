using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class Test : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _dbContext;

    public Test(ILogger<Test> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        return Ok(_dbContext.Users.ToList());
    }

    [HttpGet("seed-ads")]
    public string SeedAds()
    {
        // remove all ads before seed it
        _dbContext.Ads.RemoveRange(_dbContext.Ads.ToList());
        _dbContext.SaveChanges();

        var adFaker = new Faker<Ad>();
        var rand = new Random();

        var images = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg" };
        var authors = _dbContext.Users.ToList();
        var status = new List<int>() { 1, 2, 3 };
        var colors = new List<string>() { "Đỏ", "Vàng", "Xanh lá", "Hồng", "Tím nhạt" };
        var origins = new List<string>() { "Việt Nam", "USA", "Anh", "Trung Quốc", "Nhật Bản" };
        var genres = _dbContext.Genres.ToArray();


        adFaker.RuleFor(x => x.Title, fk => fk.Commerce.ProductName());
        adFaker.RuleFor(x => x.Author, fk => fk.PickRandom(authors));
        adFaker.RuleFor(x => x.Description, fk => fk.Lorem.Paragraph(2));
        adFaker.RuleFor(x => x.Status, fk => fk.PickRandom(true, false));
        adFaker.RuleFor(x => x.Color, fk => fk.PickRandom(colors));
        adFaker.RuleFor(x => x.Origin, fk => fk.PickRandom(origins));
        for (int i = 0; i < 100; i++)
        {

            var ad = adFaker.Generate();

            // add price
            ad.Price = rand.Next(10000, 1000000);

            var dat = DateTime.Now;
            ad.CreatedAt = dat;
            _dbContext.Ads.Add(ad);
            _dbContext.SaveChanges();

            ad = _dbContext.Ads.FirstOrDefault(x => x.CreatedAt == dat);


            // ad genres (1-3)
            var addedCates = new List<int>();
            var catesCount = rand.Next(1, 4);
            var y = 0;
            var randomIndex = 0;
            ad.Genres = new List<Genre>();
            while (y < catesCount)
            {
                randomIndex = rand.Next(genres.Count());

                if (addedCates.Contains(randomIndex))
                    continue;
                ad.Genres.Add(genres[randomIndex]);
                addedCates.Add(randomIndex);
                y++;
            }


            // ad images (1-3)
            var addedImage = new List<int>();
            var imgCount = rand.Next(1, 4);
            var x = 0;
            var randomIndexImg = 0;
            ad.Images = new List<AdImage>();
            while (x < imgCount)
            {
                randomIndexImg = rand.Next(images.Count());
                if (addedImage.Contains(randomIndexImg))
                    continue;
                ad.Images.Add(new AdImage()
                {
                    AdId = ad.Id,
                    Image = images[randomIndexImg],
                });
                addedImage.Add(randomIndexImg);
                x++;
            }


        }
        return "OK";
    }


}
