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
                    Address = "5M2",
                    Description = "ABC",
                    Email = "tqsinh_21th@student.agu.edu.vn",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 3, 11),
                    Province = "Tỉnh An Giang",
                    District = "Thành phố Long Xuyên",
                    Ward = "Phường Mỹ Long",
                },
                new Customer() {
                    Id = 2,
                    FullName = "Hồ Minh Nguyên",
                    Phone = "0913615294",
                    Password = "123123",
                    Avatar = "customerAvatar.jpg",
                    Address = "60C",
                    Description = "XYZ",
                    Email = "hmnguyen_21th@student.agu.edu.vn",
                    Gender = true,
                    DateOfBirth = new DateTime(2002, 4, 12),
                    Province =  "Tỉnh An Giang",
                    District = "Thành phố Long Xuyên",
                    Ward = "Phường Mỹ Bình",
                },
                new Customer() {
                    Id = 3,
                    FullName = "Nguyễn Thị Kim Nguyệt",
                    Phone = "0941482144",
                    Password = "123123",
                    Avatar = "customerAvatar.jpg",
                    Address = "30/12A",
                    Description = "ABCXYZ",
                    Email = "ntknguyet_21th@student.agu.edu.vn",
                    Gender = false,
                    DateOfBirth = new DateTime(2002, 7, 18),
                    Province = "Tỉnh Kiên Giang",
                    District = "Thành phố Rạch Giá",
                    Ward = "Phường Vĩnh Quang",
                },

            };

            return initData;
        }
    }
}