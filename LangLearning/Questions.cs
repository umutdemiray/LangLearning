using System.ComponentModel.DataAnnotations;

namespace LangLearning
{
    public class Questions
    {
        [Key] public int id { get; set; }

        public string questionContent { get; set; } = string.Empty;

        public string answer1 { get; set; } = string.Empty;

        public string answer2 { get; set; } = string.Empty;

        public string answer3 { get; set; } = string.Empty;

        public string answer4 { get; set; } = string.Empty;

        public string correctAnswer { get; set; } = string.Empty;

        public int examId { get; set; }

    }
}
