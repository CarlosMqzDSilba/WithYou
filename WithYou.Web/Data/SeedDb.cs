namespace WithYou.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Web.Data.Entities;
    using Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();

            await userHelper.CheckRoleAsync("Admin");
            await userHelper.CheckRoleAsync("Researcher");
            await userHelper.CheckRoleAsync("Leader");

            await CheckGendersAsync();

            if (!dataContext.Managers.Any())
            {
                var manager = await CheckUserAsync("Márquez", "Carlos", "carlos_mai11@hotmail.com", "2381338493", "123456", "Admin");
                await CheckManagersAsync(manager);
            }
        }

        private async Task CheckGendersAsync()
        {
            if (!dataContext.Genders.Any())
            {
                dataContext.Genders.Add(new Gender { Name = "FEMENINO" });
                dataContext.Genders.Add(new Gender { Name = "MASCULINO" });
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckManagersAsync(User user)
        {
            dataContext.Managers.Add(new Manager { User = user });
            await dataContext.SaveChangesAsync();
        }

        private async Task<User> CheckUserAsync(string lastName, string firstName, string mail, string phone, string password, string rol)
        {
            var user = await userHelper.GetUserByEmailAsync(mail);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = mail,
                    UserName = mail,
                    PhoneNumber = phone,
                };

                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se puede crear el usuario en la base de datos");
                }
                await userHelper.AddUserToRoleAsync(user, rol);
            }
            return user;
        }
    }
}
