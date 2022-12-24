using System.ComponentModel.DataAnnotations;

namespace LangLearning
{
    public class Users
    {

        [Key] public int id { get; set; }
        public string username { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string phone { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;

    }

}
