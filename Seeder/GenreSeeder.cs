using App.Models;

namespace App.Seeder
{
    public class GenreSeeder
    {
        public static List<Genre> Seed()
        {
            var initData = new List<Genre>() {
                new Genre() {
                    Id = 1, Title = "Đồ điện tử", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",
                },
                new Genre() {
                    Id = 2, Title = "Điện thoại", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 1
                },
                new Genre() {
                    Id = 3, Title = "Máy tính bảng", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",ParentId = 1
                },
                new Genre() {
                    Id = 4, Title = "Laptop", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 1
                },

                new Genre() {
                    Id = 5, Title = "Đồ gia dụng", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",
                },
                new Genre() {
                    Id = 6, Title = "Giường, chăn ga", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 5
                },
                new Genre() {
                    Id = 7, Title = "Dụng cụ bếp", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",ParentId = 5
                },
                new Genre() {
                    Id = 8, Title = "Đèn", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 5
                },

            };

            return initData;
        }
    }
}