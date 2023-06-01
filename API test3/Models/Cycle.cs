using System.ComponentModel.DataAnnotations;

namespace API_test3.Models
{
    public class Cycle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectionNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
