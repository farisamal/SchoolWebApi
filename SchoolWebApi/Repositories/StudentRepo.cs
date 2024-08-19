using SchoolWebApi.Models;
using System.Text.Json;

namespace SchoolWebApi.Repositories
{
    public class StudentRepo
    {
        private readonly string _jsonFilePath = "Data/students.json";

        public IEnumerable<Student> GetAll()
        {
            using (StreamReader r = new StreamReader(_jsonFilePath))
            {
                string json = r.ReadToEnd();
                IEnumerable<Student> students = JsonSerializer.Deserialize<IEnumerable<Student>>(json);
                return students;
            }
        }
        public Student Get(int id)
        {
            var students = GetAll();
            Student student = students.FirstOrDefault(s => s.ID == id);
            return student;
        }
        public int Add(Student student)
        {
            IList<Student> students = GetAll().ToList();
            students.Add(student);
            // menuliskan kembali list, ke file json
            WriteToJson(students);
            return students.Count;
        }
        public int Delete(int id)
        {
            // cek dulu id nya ada atau tidak
            // kalau ada hapus
            // kalau tidak return 0;
            var students = GetAll();
            bool idExists = students.Any(s => s.ID == id);
            if (idExists)
            {
                Student toBeDeleted = students.FirstOrDefault(s => s.ID == id);
                IList<Student> list = students.ToList();
                list.Remove(toBeDeleted);
                WriteToJson(list);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void WriteToJson(IEnumerable<Student> students)
        {
            // menuliskan kembali list, ke file json
            using (StreamWriter r = new StreamWriter(_jsonFilePath))
            {
                string all = JsonSerializer.Serialize(students);
                r.WriteLine(all);
            }
        }
    }
}
