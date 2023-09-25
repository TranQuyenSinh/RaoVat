using App.Models;

namespace App.Seeder
{
    public class GenreSeeder
    {
        public static List<Genre> Seed()
        {
            var initData = new List<Genre>() {
                new Genre() {
                    Id = 1, Title = "Đồ điện tử", Slug="do-dien-tu", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",
                },
                new Genre() {
                    Id = 2, Title = "Điện thoại", Slug="dien-thoai", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 1
                },
                new Genre() {
                    Id = 3, Title = "Máy tính bảng",  Slug="may-tinh-bang",Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",ParentId = 1
                },
                new Genre() {
                    Id = 4, Title = "Laptop",  Slug="laptop",Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 1
                },

                new Genre() {
                    Id = 5, Title = "Đồ gia dụng",  Slug="do-gia-dung",Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",
                },
                new Genre() {
                    Id = 6, Title = "Giường, chăn ga", Slug="giuong-chan-ga", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 5
                },
                new Genre() {
                    Id = 7, Title = "Dụng cụ bếp",  Slug="dung-cu-bep",Description = "ABC", Image = "genreimage.png", Icon="genreicon.png",ParentId = 5
                },
                new Genre() {
                    Id = 8, Title = "Đèn", Slug="den", Description = "ABC", Image = "genreimage.png", Icon="genreicon.png", ParentId = 5
                },

            };

            return initData;
        }
    }
}