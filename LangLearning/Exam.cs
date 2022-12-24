using System.ComponentModel.DataAnnotations;

namespace LangLearning
{
    public class Exam
    {
        [Key] public int examId { get; set; }
        public string examname { get; set; }= string.Empty;

        public string difficulty { get; set; } = string.Empty;

        //public List<Questions> Questions { get; set; }
    }
}
