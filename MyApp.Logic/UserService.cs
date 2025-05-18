using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DataAccess;
using MyApp.DataAccess.Model;

namespace MyApp.Logic
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task CreateAsync(string login, string password, string name, int gender, DateOnly? birthday, bool isAdmin, string createdBy, string modifiedBy)
        {
            var user = new User
            {
                Login = login,
                Password = password,
                Name = name,
                Gender = gender,
                Birthday = birthday,
                Admin = isAdmin,
                Createdby = createdBy, //временное решение
                Modifiedby = modifiedBy //временное решение

            };

            await userRepository.CreateAsync(user);
        }

        public async Task<List<User>> ReadWhereRevokedOnIsNull()
        {
           return await userRepository.ReadWhereRevokedOnIsNull();
        }



        public async Task<string> ReadyByLoginAndPassword(string login, string password)
        {
            var user = await userRepository.ReadyByLoginAndPassword(login, password);
            if (user == null) return "Пользователь не найден";

            return $"Login: {user.Login}, Name: {user.Name}, Gender: {user.Gender}, Birthday: {user.Birthday}";
        }

        public async Task<List<User>> ReadWhereAgeMoreThan(int age)
        {
            return await userRepository.ReadWhereAgeMoreThan(age);
        }

        public async Task<string> ReadByLogin(string login)
        {
            var user = await userRepository.ReadyByLogin(login);
            if (user == null) return "Пользователь не найден";

            return $"Login: {user.Login}";
        }


        public async Task UpdateNameGenderOrBirthday(string login, string name, int gender, DateOnly? birthday)
        {
            var user = await userRepository.ReadyByLogin(login);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            };

            user.Name = name;
            user.Gender = gender;
            user.Birthday = birthday;

            await userRepository.UpdateNameGenderOrBirthday(user);
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
