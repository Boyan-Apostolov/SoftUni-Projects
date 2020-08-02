using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace P03_Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
            
        }

        public string Call(string number)
        {
            bool hasCharacter = number.Any(char.IsLetter);
            if (hasCharacter)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid number!");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Dialing... {number}");
                return sb.ToString();
            }
        }
    }
}
