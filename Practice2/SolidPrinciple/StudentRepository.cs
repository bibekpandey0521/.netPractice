using Microsoft.EntityFrameworkCore;
using Practice2.Models;
namespace Practice2.SolidPrinciple
{
    public class StudentRepository : IStudentRepository
    {
        //public List<Student> StudentList() 
        //{
        //    List<Student> s = new()
        //    {
        //        new Student{ Id = 1, Name="Hari", Address="ktm"},
        //        new Student{ Id = 2, Name="Ramesh", Address="Bkt"},
        //        new Student{ Id = 3, Name="Shyam", Address="Pkr"},
        //    };
        //    return s;
        //}
        private readonly CrudPracticeContext _appContext;
        public StudentRepository(CrudPracticeContext appContext)
        {
            _appContext = appContext;
        }
        public IEnumerable<UserList> GetList()
        {
            var u = _appContext.UserLists.ToList();
            return u;
        }

        public void AddStudent(UserList user)
        {
        
            _appContext.Add(user);
            _appContext.SaveChanges();
            

        }

        public UserList  GetStudentById(int id)
        {
            var a = _appContext.UserLists.Where(x=>x.userId == id).First();
            return a;
        }
        public void UpdateStudent(UserList user)
        {

        }
        public void DeleteStudent(int id) { 

        }
    }
}
