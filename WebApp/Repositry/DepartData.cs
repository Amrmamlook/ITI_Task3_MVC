using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositry
{
    public class DepartData
    {
        DataContext dataContext = new DataContext();
        public List<Department> GEtAll()
        {
            return dataContext.Departments.ToList();
        }
        public Department GEtById(int id)
        {
            return dataContext.Departments.FirstOrDefault(e => e.Id == id);
        }
        public Department Update(Department updatedDepartment)
        {
            var existingDepartment = dataContext.Departments.FirstOrDefault(d => d.Id == updatedDepartment.Id);

            if (existingDepartment != null)
            {
                existingDepartment.NameDepart = updatedDepartment.NameDepart;
                existingDepartment.Manager = updatedDepartment.Manager;

                dataContext.SaveChanges();
            }

            return existingDepartment;
        }

        public void Delete(int id)
        {
            Department user = dataContext.Departments.Include(e=>e.Users).FirstOrDefault(u => u.Id == id);
            dataContext.Departments.Remove(user);
            dataContext.SaveChanges();
        }
        public Department Add(Department user)
        {
            dataContext.Departments.Add(user);
            dataContext.SaveChanges();
            return user;
        }
    }
}
