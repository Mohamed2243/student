using System.ComponentModel.DataAnnotations;

namespace Exam.Model
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name{get; set; }
        public string number { get; set; }


    }
}
