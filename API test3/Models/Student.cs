using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_test3.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        public string? HashPass { get; set; }
        public string Phone { get; set; }
        public int CycleId { get; set; }

        // Navigation property
        [ForeignKey("CycleId")]
        public Cycle? Cycle { get; set; }

    }
}
