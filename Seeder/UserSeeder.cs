using App.Models;

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
                    UserName = "admin",
                    Password = "123123",
                    RoleId = 1
                },
                new User() {
                    Id = 2,
                    FullName = "Nguyễn Phước Tài",
                    UserName = "admin2",
                    Password = "123123",
                    RoleId = 1
                },
                new User() {
                    Id = 3,
                    FullName = "Đặng Hào Phong",
                    UserName = "censor",
                    Password = "123123",
                    RoleId = 2
                },

            };

            return initData;
        }
    }
}