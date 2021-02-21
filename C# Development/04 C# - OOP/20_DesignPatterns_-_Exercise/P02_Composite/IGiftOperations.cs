using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Composite
{
    public interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
