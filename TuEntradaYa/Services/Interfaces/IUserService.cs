using TuEntradaYa.Models.Dtos.User;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        public  Users? GetUserById(int id);

        //public Users? GetUserByName(string name);

        bool AddUser(UserCreateDto user);

        bool UpdateUser(int userId, UserUpateDto user);

        bool DeleteUser(int userId);

        public Users? GetUserByEmail(string email);

        public Users? GetUserByUsername(string username);

        public Users? Authenticate(string email, string password);
    }
}
