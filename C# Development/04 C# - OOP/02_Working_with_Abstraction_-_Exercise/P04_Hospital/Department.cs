using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        private readonly List<Room> rooms;
        private Department()
        {
            this.rooms = new List<Room>();
            InitializeRooms();
        }
        public Department(string name) :this()
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public IReadOnlyCollection<Room> Rooms => this.rooms;
        private void InitializeRooms()
        {
            for (byte i = 1; i <= 20; i++)
            {
                this.rooms.Add(new Room(i));
            }
        }
    }
}
