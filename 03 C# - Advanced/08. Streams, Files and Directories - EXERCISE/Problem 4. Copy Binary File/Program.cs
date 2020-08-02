using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open);

            using FileStream writer = new FileStream("coppied.png", FileMode.Create);

            byte[] buffer = new byte[4096];

            while (reader.CanRead)
            {
                int bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
