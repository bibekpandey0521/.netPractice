using Practice2.Models;
namespace Practice2.SolidPrinciple
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo) {
            this._repo = repo;
        }

        public IEnumerable<UserList> GetStudents() => _repo.GetList();

        public UserList GetStdById(int id)
        {
            return _repo.GetStudentById(id);
        } 
        public void AddStd(UserList  std)
        {
            _repo.AddStudent(std);
        }
        public void DeleteStd(int id) 
        { 
            _repo.DeleteStudent(id);
        }
        public void UpdateStd(UserList s) 
        { 
            _repo.UpdateStudent(s);
        }
    }
}
