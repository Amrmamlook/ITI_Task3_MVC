using WebApp.Models;

namespace WebApp.Repositry
{
    public interface IUser
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User Update(User user);
        public void Delete(int id);
        public User Add(User user);
    }
}

