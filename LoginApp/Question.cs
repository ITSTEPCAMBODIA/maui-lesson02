using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    public class Question
    {
        public string Title { get; set; } = "Untitled";//2 + 3 = ?
        public List<string> Answers { get; set; } = []; //a. 3
                                                        //b. 4
                                                        //c. 5
                                                        //d. 6
                                                        //e. 7
        public List<int> CorrectAnswers { get; set; } = [];//2
    }
    public class Section
    {
        public string Name { get; set; } = "Unnamed";//History, Geography, Biology, etc
        public List<Question> Questions { get; set; } = [];
        public List<Quiz> Quizzes { get; set; } = [];
    }
    public class QuestionBank
    {
        public List<Section> Sections { get; set; } = [];
        public List<Attempt> Attempts { get; set; } = [];
        private static string FileName = @"D:\Work\2023\PTSD15\MAUI\Lesson02\Data.json";
        public static QuestionBank LoadFromFile() {
            if (!File.Exists(FileName)) return new QuestionBank();
            QuestionBank? bank = JsonConvert.DeserializeObject<QuestionBank>(
                File.ReadAllText(FileName));
            if(bank != null)
            {
                foreach(var section in bank.Sections)
                {
                    foreach(var quiz in section.Quizzes)
                    {
                        quiz.Attempts.AddRange(
                            from attempt in bank.Attempts
                            where attempt.Quiz.Id == quiz.Id
                            select attempt
                            );
                    }
                }
            }
            return bank??new QuestionBank();
        }
        public void SaveToFile() {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(this));
        }
    }
}
