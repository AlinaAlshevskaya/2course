using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class AAMDirInfo
    {
       
        
            public static void PrintInfo(string path)
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    var a = dirInfo.EnumerateFiles();
                    var b = dirInfo.EnumerateDirectories();

                    Console.WriteLine($"Название каталога: {dirInfo.Name}");
                    Console.WriteLine($"Кол-во файлов: {a.Count()}");
                    Console.WriteLine($"Кол-во поддиректориев: {b.Count()}");
                    Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                    Console.WriteLine($"Родительские директории: {dirInfo.Parent}");
                    lab12.AAMLog.WriteLog(dirInfo.Name, dirInfo.Name, "AAMFileInfo.PrintInfo()");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        
    }
}
