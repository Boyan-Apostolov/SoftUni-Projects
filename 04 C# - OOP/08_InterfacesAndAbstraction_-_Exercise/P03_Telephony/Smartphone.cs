using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_Telephony
{
    class Smartphone : ICallable,IBrowseble
    {
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
                sb.Append($"Calling... {number}");
                return sb.ToString();
            }
        }

        public string Browse(string url)
        {
            bool hasDigit = url.Any(char.IsDigit);
            if (hasDigit)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid URL!");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Browsing: {url}!");
                return sb.ToString();
            }
        }
    }
}
