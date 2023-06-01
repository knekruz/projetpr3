using System.ComponentModel.DataAnnotations;

namespace API_test3.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string? HashPass { get; set; }
    }
}
