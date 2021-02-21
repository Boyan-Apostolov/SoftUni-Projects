using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
