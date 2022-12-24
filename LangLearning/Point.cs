using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LangLearning
{
    public class Point
    {
        //[Key, Column(Order = 0)]
        public int examId { get; set; }
        //[Key, Column(Order = 1)]
        public int userId { get; set; }

        //[Key, Column(Order = 2)]
        public DateTime currDate { get; set; } = DateTime.Now;

        public int grade { get; set; }
        


    }
}
