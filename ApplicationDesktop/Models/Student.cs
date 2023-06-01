using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDesktop.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CycleId { get; set; }


        public Student() {}

        public Student(int id, string name,string lastName, DateTime birthDate, string email, string phone, int cycleId)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            CycleId = cycleId;
        }

        public Student(string name, string lastName, DateTime birthDate, string email, string phone, int cycleId)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            CycleId = cycleId;
        }
    }
}
