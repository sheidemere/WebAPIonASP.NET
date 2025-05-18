using MyApp.DataAccess.Model;

namespace MyApp.Logic
{
    public interface IUserService
    {
        Task CreateAsync(string login, string password, string name, int gender, DateOnly? birthday, bool isAdmin, string createdBy, string modifiedBy);
        Task<List<User>> ReadWhereRevokedOnIsNull();

        Task<string> ReadByLogin(string login);
        Task<string> ReadyByLoginAndPassword(string login, string password);
        Task<List<User>> ReadWhereAgeMoreThan(int age);


        Task UpdateNameGenderOrBirthday(string login, string name, int gender, DateOnly? birthday);
        Task UpdatePassword(User user);
        Task UpdateLogin(User user);



    }
}
