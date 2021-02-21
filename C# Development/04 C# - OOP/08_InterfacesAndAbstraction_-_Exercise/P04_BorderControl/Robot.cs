using System;
using System.Collections.Generic;
using System.Text;

namespace P04_BorderControl
{
    public class Robot : IRobot, IIdHolder
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }
        public string Id { get; }
    }
}
