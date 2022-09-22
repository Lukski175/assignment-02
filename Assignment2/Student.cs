using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public record ImmutableStudent(int Id, string GivenName, string SurName, DateTime StartDate, DateTime EndDate, DateTime GraduationDate)
    {
        public Status Status
        {
            get
            {
                bool newStudent = StartDate.Date == DateTime.Now.Date;
                bool graduated = GraduationDate.Date <= DateTime.Now.Date;
                bool dropout = !graduated && EndDate.Date <= DateTime.Now.Date && EndDate > DateTime.MinValue;
                bool active = !graduated && !dropout;

                if (newStudent) return Status.New;
                if (active) return Status.Active;
                if (dropout) return Status.Dropout;
                return Status.Graduated;
            }
        }
    }

    public class Student
    {
        public int Id { get; init; }
        public string GivenName { get; set; }

        public string SurName { get; set; }

        public Status Status
        {
            get
            {
                bool newStudent = StartDate.Date == DateTime.Now.Date;
                bool graduated = GraduationDate.Date <= DateTime.Now.Date;
                bool dropout = !graduated && EndDate.Date <= DateTime.Now.Date && EndDate > DateTime.MinValue;
                bool active = !graduated && !dropout;

                if (newStudent) return Status.New;
                if (active) return Status.Active;
                if (dropout) return Status.Dropout;
                return Status.Graduated;
            }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime GraduationDate { get; set; }


        public override string ToString()
        {
            return $"Student id: {Id}, full name: {GivenName} {SurName}";
        }
    }
}

public enum Status
{
    New, Active, Dropout, Graduated
}

