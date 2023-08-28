using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositry
{
    public class UserData :IUser
    {
        public DataContext DataContext = new DataContext();
        public List<User>GetAll()
        {
            return DataContext.Users.Include(e=>e.Department).ToList();
        }
        public User GetById(int id) 
        {
            return DataContext.Users.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }
        
        public User Update(User user )
        {
             DataContext.Users.Update(user);
            DataContext.SaveChanges();
            return user;

        }
        public void Delete(int id)
        {
            User user = DataContext.Users.Include(e => e.Department).FirstOrDefault(u => u.Id == id);
            DataContext.Users.Remove(user);
            DataContext.SaveChanges();
        }
        public User Add(User user) 
        {
            DataContext.Users.Add(user);
            DataContext.SaveChanges();
            return user;
        }

    }
}
