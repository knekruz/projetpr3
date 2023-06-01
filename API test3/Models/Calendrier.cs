using System.ComponentModel.DataAnnotations;

namespace API_test3.Models
{
    public class Calendrier
    {
        [Key]
        public int Id { get; set; }
        public DateTime Jour { get; set; }
    }
}
