using App.Models;
using App.Utils;

namespace App.Seeder
{
    public class UserSeeder
    {
        public static List<User> Seed()
        {
            var initData = new List<User>() {
                new User() {
                    Id = 1,
                    FullName = "Trần Quyền Sinh",
                    Email = "admin@gmail.com",
                    Password =PasswordHasher.Hash("123123"),
                    Phone = "0818283714",
                    Avatar = "customerAvatar.jpg",
                    Address = "5M2",
                    Description = "ABC",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 3, 11),
                    Province = "Tỉnh An Giang",
                    District = "Thành phố Long Xuyên",
                    Ward = "Phường Mỹ Long",
                    RoleId = 1,
                },
                new User() {
                    Id = 2,
                    FullName = "Hồ Minh Nguyên",
                    Email = "censor@gmail.com",
                    Phone = "0913615294",
                    Password =PasswordHasher.Hash("123123"),
                    Avatar = "customerAvatar.jpg",
                    Address = "60C",
                    Description = "XYZ",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 4, 12),
                    Province =  "Tỉnh An Giang",
                    District = "Thành phố Long Xuyên",
                    Ward = "Phường Mỹ Bình",
                    RoleId = 2,
                },
                new User() {
                    Id = 3,
                    FullName = "Nguyễn Thị Kim Nguyệt",
                    Email = "guest@gmail.com",
                    Phone = "0941482144",
                    Password =PasswordHasher.Hash("123123"),
                    Avatar = "customerAvatar.jpg",
                    Address = "30/12A",
                    Description = "ABCXYZ",
                    Gender = false,
                    DateOfBirth = new DateTime(2002, 7, 18),
                    Province = "Tỉnh Kiên Giang",
                    District = "Thành phố Rạch Giá",
                    Ward = "Phường Vĩnh Quang",
                    RoleId = 3,
                },

            };

            return initData;
        }
    }
}