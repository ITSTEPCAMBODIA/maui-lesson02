using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoginApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
    public class StudentList
    {
        public List<Student> Students { get; set; } = [];
        public static StudentList LoadFromFile()
        {
            if (!File.Exists("Students.json")) return null;
            StudentList? list = JsonConvert.DeserializeObject<StudentList>(
                File.ReadAllText("Students.json"));
            return list ?? new StudentList();
        }
        public void SaveToFile()
        {
            File.WriteAllText("Students.json", JsonConvert.SerializeObject(this));
        }
    }
    public class Attempt
    {
        public Student Student { get; set; }
        public Quiz Quiz { get; set; }
        public DateTime AttemptDate { get; set; }= DateTime.Now;
        public int Score { get; set; } = 0;

        public Attempt(Student student, Quiz quiz)
        {
            Student = student;
            Quiz = quiz;
        }
    }
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Quiz001 Math";
        public List<Question> Questions { get; set; } = new();
        [Newtonsoft.Json.JsonIgnore]
        public List<Attempt> Attempts { get; set; } = new();
    }
}
