using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string dir = @"D:\Semester_8_SP26\SmartRecruit\SmartRecruit.WebPortal\Pages";
        string search = "SmartRecruitWeb";
        string replace = "WebPortal";

        string[] files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
        int count = 0;
        foreach (string file in files)
        {
            if (file.EndsWith(".cs") || file.EndsWith(".cshtml"))
            {
                string text = File.ReadAllText(file);
                if (text.Contains(search))
                {
                    text = text.Replace(search, replace);
                    File.WriteAllText(file, text);
                    count++;
                }
            }
        }
        Console.WriteLine($"Replaced namespace in {count} files.");
    }
}
