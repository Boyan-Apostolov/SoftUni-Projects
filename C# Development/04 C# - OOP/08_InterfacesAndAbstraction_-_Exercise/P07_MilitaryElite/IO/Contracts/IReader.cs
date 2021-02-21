using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.IO.Contracts
{
    public interface IReader
    {
        void Read(string text);
        void ReadLine(string text);
    }
}
