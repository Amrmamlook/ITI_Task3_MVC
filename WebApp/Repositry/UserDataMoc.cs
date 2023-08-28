using WebApp.Models;

namespace WebApp.Repositry
{
    public class UserDataMoc :IUser
    {
        List<User> _users = new List<User>()
        {
            new User() {Name="Maged",Age=45,Password="12355",CPassword="12355",Email="Gorege@gmail.com",DeparId=2,Department=new Department{Id=2,NameDepart="SE"}},
            new User() {Name="Naveen",Age=35,Password="1445",CPassword="1445",Email="Naveen@gmail.com",DeparId=3,Department=new Department{Id=2,NameDepart="SE"}},
            new User() {Name="porege",Age=55,Password="1255",CPassword="1255",Email="porege@gmail.com",DeparId=3,Department=new Department{Id=3,NameDepart="IT"}}
         };
        public List<User> GetAll()
        {
            return _users;
        }
        public User GetById(int id)
        {
            return _users.FirstOrDefault(e => e.Id == id);
        }
        public User Add(User user)
        {
            _users.Add(user);
            return user;
        }
        public void Delete(int id)
        {

        }
        public User Update(User user)
        {
            return user;
        }
    }
}
