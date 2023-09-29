using App.Models;

namespace App.Seeder
{
    public class RoleSeeder
    {
        public static List<Role> Seed()
        {
            var initData = new List<Role>() {
                new Role() {Id = 1, RoleName = "Administrator"},
                new Role() {Id = 2, RoleName = "Censor"},
                new Role() {Id = 3, RoleName = "Guest"},
            };

            return initData;
        }
    }
}