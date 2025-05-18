using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.DataAccess.Model;

namespace MyApp.DataAccess
{
    internal class UserRepository(MyAppContext context) : IUserRepository
    {
        public async Task CreateAsync(User user)
        {           
            user.Createdon = DateTime.Now;
            //user.Createdby TODO
            user.Modifiedon = DateTime.Now;
            //user.Modifiedby TODO

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> ReadWhereRevokedOnIsNull()
        {
            return await context.Users.Where(u=>u.Revokedon ==null).OrderByDescending(x=>x.Createdon).ToListAsync();
        }

        public async Task<User?> ReadyByLogin(string login)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<User?> ReadyByLoginAndPassword(string login, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task<List<User>> ReadWhereAgeMoreThan(int age)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var cutoffDate = today.AddYears(-age);

            return await context.Users
                .Where(u => u.Birthday.HasValue && u.Birthday.Value <= cutoffDate)
                .OrderByDescending(u => u.Createdon)
                .ToListAsync();
        }


        public async Task UpdateNameGenderOrBirthday(User user)
        {
            user.Modifiedon = DateTime.UtcNow;
            //user.Modifiedby TODO
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public Task UpdatePassword(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLogin(User user)
        {
            throw new NotImplementedException();
        }
    }
}