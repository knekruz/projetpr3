using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_test3.Models
{
    public class Pointage
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for Student
        public int StudentId { get; set; }

        public DateTime TimestampPointage { get; set; }
    }
}
