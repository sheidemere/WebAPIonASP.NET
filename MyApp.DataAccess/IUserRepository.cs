using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DataAccess.Model;

namespace MyApp.DataAccess
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<List<User>> ReadWhereRevokedOnIsNull();

        Task<User?> ReadyByLogin(string login);
        Task<User?> ReadyByLoginAndPassword(string login, string password);

        Task<List<User>> ReadWhereAgeMoreThan(int age);




        Task UpdateNameGenderOrBirthday(User user);
        Task UpdatePassword(User user);
        Task UpdateLogin(User user);
    }
}
