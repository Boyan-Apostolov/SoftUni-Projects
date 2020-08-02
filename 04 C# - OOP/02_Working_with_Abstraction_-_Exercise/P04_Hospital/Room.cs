using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private List<Patient> patients;
        private const int MAX_CAPACITY = 3;

        private Room()
        {
            this.patients = new List<Patient>();
        }

        public Room(byte number)
        {
            this.Number = number;
        }
        public byte Number { get;}
        public List<Patient> Patients => this.patients;
        public int Count => this.Patients.Count;
        public void AddPatient(Patient patient)
        {
            if (this.Count < MAX_CAPACITY)
            {
                this.patients.Add(patient);
            }
        }
    }
}
