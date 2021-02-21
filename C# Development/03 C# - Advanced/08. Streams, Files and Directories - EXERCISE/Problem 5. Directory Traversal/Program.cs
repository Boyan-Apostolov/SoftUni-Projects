using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Problem_5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDir = Console.ReadLine();

            string[] files = Directory.GetFiles(inputDir);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathString = System.IO.Path.Combine(path, "results.txt");
            using FileStream writer = new FileStream(pathString, FileMode.Create);//
            StreamWriter fs = new StreamWriter(writer);

            Dictionary<string, Dictionary<string, float>> info = new Dictionary<string, Dictionary<string, float>>();

            foreach (var filePath in files)
            {
                string filename = filePath.Split('\\').Last();

                string extention = filename.Split('.').Last();
                string name = filename.Split('.').First();

                FileInfo fileInfo = new FileInfo(filename);

                float fileSize = 1+fileInfo.Length / 1024;


                if (!info.ContainsKey(extention))
                {
                    info.Add(extention, new Dictionary<string, float>());
                }
                if (!info[extention].ContainsKey(name))
                {
                    info[extention].Add(name, 0);
                }
                info[extention][name] = fileSize;
            }

            foreach (var item in info.OrderByDescending(x=>x.Value.Count).ThenBy(y=>y.Key))
            {
                fs.WriteLine('.' + item.Key);
                fs.Flush();
                foreach (var things in info[item.Key].OrderBy(x=>x.Value))
                {
                    string name = things.Key;
                    float size = things.Value;

                    fs.WriteLine($"--{name}.{item.Key} - {size}kb");
                    fs.Flush();
                }

            }
            fs.Close();
        }
    }
}
