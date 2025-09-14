using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class AAMFileManager
    {
        public static List<string> GetFilesAndDir(string disk)
        {
            try
            {
                DriveInfo drive = new DriveInfo(disk);
                List<string> entries = new List<string>();
                var buffer = drive.RootDirectory.EnumerateFiles();
                foreach (var file in buffer)
                {
                    entries.Add(file.Name);
                }
                var buffer2 = drive.RootDirectory.EnumerateDirectories();
                foreach (var dir in buffer2)
                {
                    entries.Add(dir.Name);
                }
                lab12.AAMLog.WriteLog(drive.Name, drive.Name, "AAMFileManager.GetFilesAndDir()");
                return entries;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }

        }
        public static void CreateDir(string path)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                lab12.AAMLog.WriteLog(path, path, "AAMFileManager.CreateDir()");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void DeleteDir(string path)
        {
            try { Directory.Delete(path); lab12.AAMLog.WriteLog(path, path, "AAMFileManager.DeleteDir()"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void CreateFile(string path)
        {
            try { File.Create(path).Close(); lab12.AAMLog.WriteLog(path, path, "AAMFileManager.CreateFile()"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeleteFile(string path)
        {
            try { File.Delete(path); lab12.AAMLog.WriteLog(path, path, "AAMFileManager.DeleteFile()"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteFile(string path, string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path)) { sw.WriteLine(text); }
                lab12.AAMLog.WriteLog(path, path, "AAMFileManager.WriteFile()");

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void CopyFilesTo(string from, string to)
        {
            try
            {
                DirectoryInfo source = new DirectoryInfo(from);
                var files = source.GetFiles();
                foreach (var file in files)
                {
                    file.CopyTo(to);
                }
                lab12.AAMLog.WriteLog(from, from, "AAMFileManager.CopyFilesTO() источник для копирования");
                lab12.AAMLog.WriteLog(to, to, "AAMFileManager.CopyFilesTO() результат копирования");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void CopyFilesTo(string from, string to, string extension)
        {
            try
            {
                DirectoryInfo source = new DirectoryInfo(from);
                var files = source.GetFiles();
                foreach (var file in files)
                {
                    var copy = @$"{to}\{file.Name}";
                    if (file.Extension == extension && !File.Exists(copy)) file.CopyTo(copy);
                }
                lab12.AAMLog.WriteLog(from, from, "AAMFileManager.CopyFilesTO() источник для копирования");
                lab12.AAMLog.WriteLog(extension, extension, "AAMFileManager.CopyFilesTO() фильтр расширений копирования");
                lab12.AAMLog.WriteLog(to, to, "AAMFileManager.CopyFilesTO() результат копирования");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public static void CopyFile(string from, string name)
        {
            try
            {
                FileInfo source = new FileInfo(from);
                var dir = source.Directory;
                if (!File.Exists(@$"{dir.FullName}\{name}"))
                {
                    File.Create(dir.FullName + name);
                }
                List<string> buffer = new List<string>();
                using (StreamReader reader = new StreamReader(from))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        buffer.Add(line);
                    }
                    lab12.AAMLog.WriteLog(from, from, "AAMFileManager.CopyFiles() источник для копирования");
                }
                using (StreamWriter writer = new StreamWriter(@$"{dir.FullName}\{name}"))
                {

                    foreach (var line in buffer)
                    {

                        Console.WriteLine($"Копирование: {line}");
                        writer.WriteLine(line);
                    }
                }

                lab12.AAMLog.WriteLog(name, @$"{dir.FullName}\{name}", "AAMFileManager.CopyFiles() результат копирования");

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void MoveDirTo(string dir, string dest)
        {
            try
            {
                if (!Directory.Exists(dest)) Directory.Move(dir, dest);
                lab12.AAMLog.WriteLog(dir, dir, "AAMFileManager.CopyFilesTO() переносимая директория");
                lab12.AAMLog.WriteLog(dest, dest, "AAMFileManager.CopyFilesTO() место переноса");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static async void ZipFile(string source, string name)
        {
            try
            {
                await Zip(source, name);
                AAMLog.WriteLog(source, source, "AAMFileManager.ZipFile() сжимаемый файл");
                AAMLog.WriteLog(name, name, "AAMFileManager.ZipFile() полученный архив");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static async void ZipDir(string source, string name)
        {

            try
            {
                if (!File.Exists(name)) System.IO.Compression.ZipFile.CreateFromDirectory(source, name);
                AAMLog.WriteLog(source, source, "AAMFileManager.ZipFile() сжимаемый файл");
                AAMLog.WriteLog(name, name, "AAMFileManager.ZipFile() полученный архив");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        async static Task Zip(string sourceFile, string compressedFile)
        {
           
            using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
            
            using FileStream targetStream = File.Create(compressedFile);

            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            await sourceStream.CopyToAsync(compressionStream); 
            Console.WriteLine($"Сжатие файла {sourceFile} завершено.");
            Console.WriteLine($"Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}");
        }

        public static async void UnzipFile(string source, string name)
        {
            try
            {
                await Unzip(source, name);
                AAMLog.WriteLog(source, source, "AAMFileManager.UnzipFile() разжимаемый архив");
                AAMLog.WriteLog(name, name, "AAMFileManager.ZipFile() восстановленный файл");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static async void UnzipDir(string source, string name)
        {
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(source, name);
                AAMLog.WriteLog(source, source, "AAMFileManager.ZipFile() разжимамемый архив");
                AAMLog.WriteLog(name, name, "AAMFileManager.ZipFile() полученный файл");
            }
            catch (Exception e) { }
        }

        async static Task Unzip(string compressedFile, string targetFile)
        {

            using FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);
            using FileStream targetStream = File.Create(targetFile);
            using GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            await decompressionStream.CopyToAsync(targetStream);
            Console.WriteLine($"получен файл: {targetFile}");
        }

    }
}

