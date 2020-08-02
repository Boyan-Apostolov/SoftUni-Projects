using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private readonly List<Patient> patients;
        public Doctor(string firstName,string surname)
        {
            this.FirstName = name;
            this.Surname = surname;
            this.patients = new List<Patient>();
        }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public IReadOnlyCollection<Patient> Patients => this.patients;
    }
}
