using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class AAMFileInfo
    {
        public static void PrintInfo(string path)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(path);

                if (!fileInfo.Exists)
                {
                    File.Create(path);
                }
                Console.WriteLine($"Полное имя: {fileInfo.FullName}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine(fileInfo.Name + " " + fileInfo.Extension + " " + fileInfo.Length);
                lab12.AAMLog.WriteLog(fileInfo.Name, fileInfo.Name, "AAMFileInfo.PrintInfo()");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
