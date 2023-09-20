using App.Models;

namespace App.Seeder
{
    public class CustomerSeeder
    {
        public static List<Customer> Seed()
        {
            var initData = new List<Customer>() {
                new Customer() {
                    Id = 1,
                    FullName = "Trần Quyền Sinh",
                    Phone = "0818283714",
                    Password = "123123",
                    Avatar = "customerAvatar.jpg",
                    Address = "5M2, Mỹ Long, Long Xuyên, An Giang",
                    Description = "ABC",
                    Email = "tqsinh_21th@student.agu.edu.vn",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 3, 11),
                },
                new Customer() {
                    Id = 2,
                    FullName = "Hồ Minh Nguyên",
                    Phone = "0913615294",
                    Password = "123123",
                    Avatar = "customerAvatar.jpg",
                    Address = "60C, Mỹ Bình, Long Xuyên, An Giang",
                    Description = "XYZ",
                    Email = "hmnguyen_21th@student.agu.edu.vn",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 4, 12),
                },
                new Customer() {
                    Id = 3,
                    FullName = "Nguyễn Thị Kim Nguyệt",
                    Phone = "0941482144",
                    Password = "123123",
                    Avatar = "customerAvatar.jpg",
                    Address = "30/12A, Mỹ Phước, Long Xuyên, An Giang",
                    Description = "ABCXYZ",
                    Email = "ntknguyet_21th@student.agu.edu.vn",
                    Gender = false,
                    DateOfBirth = new DateTime(2002, 7, 18),
                },

            };

            return initData;
        }
    }
}