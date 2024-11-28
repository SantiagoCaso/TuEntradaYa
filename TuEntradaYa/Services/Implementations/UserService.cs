using TuEntradaYa.DBContext;
using TuEntradaYa.Models.Dtos.User;
using TuEntradaYa.Models.Entities;
using TuEntradaYa.Services.Interfaces;

namespace TuEntradaYa.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly TuEntradaYaContext _tuEntradaYaContext;


        public UserService(TuEntradaYaContext tuEntradaYaContext)
        {
            _tuEntradaYaContext = tuEntradaYaContext;
        }

        public List<Users> GetAllUsers()
        {
            return _tuEntradaYaContext.Users.ToList();
        }

        public Users? GetUserById(int id) { 
            
            var user = _tuEntradaYaContext.Users.FirstOrDefault(i => i.Id == id);

            return user;
        }

        public bool AddUser(UserCreateDto newUser)
        {
            bool userExist = _tuEntradaYaContext.Users.Any(u => u.Email == newUser.Email);

            if (userExist)
            {
                Console.WriteLine("El eamil {Email} ya pertenece a una cuanta activa", newUser.Email);
            }
             
                Users addUser = new Users
                {
                    Name = newUser.Name,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    Role = newUser.Role.ToString()
                };

                _tuEntradaYaContext.Users.Add(addUser);
                _tuEntradaYaContext.SaveChanges();
                return true;
        }

        public bool UpdateUser(UserUpateDto user)
        {
            Users? userToUpdate = _tuEntradaYaContext.Users.FirstOrDefault(u => u.Id == user.Id);
            userToUpdate.Name = user.Name;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Password = user.Password;


            _tuEntradaYaContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            Users? userToDelete = _tuEntradaYaContext.Users.FirstOrDefault(u => u.Id == userId);
            if (userToDelete == null)
            {
                Console.WriteLine("El usuario que intentas eliminar no se encuentra");
                return false;
            }


            _tuEntradaYaContext.Users.Remove(userToDelete);
            _tuEntradaYaContext.SaveChanges();
            return true;

        }

        public Users ? GetUserByEmail(string email)
        {
            Users? user =  _tuEntradaYaContext.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public Users? GetUserByUsername(string username) 
        {
            Users? user = _tuEntradaYaContext.Users.FirstOrDefault(u => u.Name == username);
            return user;
        }

        public Users ? Authenticate(string email, string password)
        {
            Users ? userToAuthenticate = _tuEntradaYaContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            return userToAuthenticate;
        }   

    }
}
