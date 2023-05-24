using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Management_System_DesktopUIAssignment.Model
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public double Gpa { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string ImageAddress { get; set; }

        
        public Student() { }

        public Student(string firstName, string lastName, double gpa, DateTime dateOfBirth, string imageAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Gpa = gpa;
            DateOfBirth = dateOfBirth;
            ImageAddress = imageAddress;
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }

            if (DateOfBirth == DateTime.MinValue)
            {
                return false;
            }

            if (Gpa <= 0 || Gpa >= 4)
            {
                return false;
            }

            return true;
        }
    }
}
