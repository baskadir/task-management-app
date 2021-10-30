using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.InitializeUserInfo
{
    public static class InitializeUser
    {
        /*
          Manager => username: kadirbas, password: 1,
          Personels => username: aliyilmaz, password: 2,
                       username: ayseyilmaz, password: 2,
                       username: mehmetyilmaz, password: 2
         */
        public static void CreateManager(UserManager<AppUser> userManager)
        {
            AppUser user = new()
            {
                FirstName = "Kadir",
                LastName = "Baş",
                UserName = "kadirbas",
                Email = "kadir@kadir.com"
            };

            if (userManager.FindByNameAsync("kadirbas").Result == null)
            {
                var result = userManager.CreateAsync(user, "1").Result;
                var result2 = userManager.AddToRoleAsync(user, "Manager").Result;
            }
        }

        public static void CreatePersonels(UserManager<AppUser> userManager)
        {
            List<AppUser> users = new List<AppUser>()
            {
                new()
                {
                    FirstName ="Ali",
                    LastName = "Yılmaz",
                    Email = "ali@ali.com",
                    UserName = "aliyilmaz"
                },
                new()
                {
                    FirstName ="Ayşe",
                    LastName = "Yılmaz",
                    Email = "ayse@ayse.com",
                    UserName = "ayseyilmaz"
                },
                new()
                {
                    FirstName ="Mehmet",
                    LastName = "Yılmaz",
                    Email = "mehmet@mehmet.com",
                    UserName = "mehmetyilmaz"
                }
            };

            foreach (var item in users)
            {
                if (!userManager.Users.Contains(item))
                {
                    var result = userManager.CreateAsync(item, "2").Result;
                    var result2 = userManager.AddToRoleAsync(item, "Personel").Result;
                }
            }
        }
    }
}
