using System;
using System.Collections.Generic;
using System.Text;

namespace P04_BorderControl
{
    public interface ICitizen 
    {
        string Name { get; }
        int Age { get; }
        string Birthdate { get; }
    }
}
