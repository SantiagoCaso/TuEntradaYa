using TuEntradaYa.Models.Dtos.User;
using TuEntradaYa.Models.Entities;

namespace TuEntradaYa.Services.Interfaces
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        public  Users? GetUserById(int id);

        bool AddUser(UserCreateDto user);

        bool UpdateUser(string email, string password, UserUpateDto user);

        bool DeleteUser(int userId);

        public Users? GetUserByEmail(string email);

        public Users? GetUserByUsername(string username);

        public Users? Authenticate(string email, string password);
    }
}
