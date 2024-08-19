using SchoolWebApi.Models;
using SchoolWebApi.Repositories;

namespace SchoolWebApi.Services
{
    public class StudentService
    {
        private readonly StudentRepo _repo;
        public StudentService(StudentRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Student> GetAll()
        {
            return _repo.GetAll();
        }

        public Student Get(int id)
        {
            return _repo.Get(id);
        }

        public int Add(Student student)
        {
            student.CreatedAt = DateTime.Now;
            return _repo.Add(student);
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
