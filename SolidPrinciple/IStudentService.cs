using Practice2.Models;
namespace Practice2.SolidPrinciple
{
    public interface IStudentService
    {
        IEnumerable<UserList> GetStudents();
        UserList  GetStdById(int id);

        void AddStd(UserList  std);

        void UpdateStd(UserList  std);
        void DeleteStd(int id);
    }
}
