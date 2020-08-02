using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public interface ICallable
    {
        string Call(string number);
    }
}
