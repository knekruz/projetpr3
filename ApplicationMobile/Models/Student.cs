using System.ComponentModel.DataAnnotations;

namespace ApplicationMobile.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string? HashPass { get; set; }
        public string Phone { get; set; }
        public string Cycle { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public DateTime CylceStart { get; set; }
        public DateTime CycleEnd { get; set; }
    }
}