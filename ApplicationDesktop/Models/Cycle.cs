using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDesktop.Models
{
    internal class Cycle
    {
        public int Id { get; set; }
        public int SectionNumber { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Cycle() { }

        // Constructor without the 'Id' parameter
        public Cycle(int sectionNumber, string name, DateTime? startDate, DateTime? endDate)
        {
            SectionNumber = sectionNumber;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Constructor with the 'Id' parameter
        public Cycle(int id, int sectionNumber, string name, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            SectionNumber = sectionNumber;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
