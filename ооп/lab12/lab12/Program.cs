using lab12;
AAMDiskInfo.PrintInfo();
Console.WriteLine();
AAMDirInfo.PrintInfo(@"D:\Documents\ооп\lab12\lab12");
Console.WriteLine();
AAMFileInfo.PrintInfo("file.txt");
var entries = AAMFileManager.GetFilesAndDir(@"D:\");
Console.WriteLine();
foreach (var entry in entries)
{
    Console.WriteLine(entry);
}
Console.WriteLine();
//task 1
AAMFileManager.CreateDir("AAMInspect");
AAMFileManager.CreateFile("AAMdirinfo.txt");
AAMFileManager.WriteFile("AAMdirinfo.txt", "HGFBCCJC");
AAMFileManager.CopyFile("AAMdirinfo.txt", "copy.txt");
AAMFileManager.DeleteFile("AAMdirinfo.txt"); 
//task 2
AAMFileManager.CreateDir("AAMFiles");
AAMFileManager.CopyFilesTo(@"D:\Documents\ооп\lab12\lab12", "AAMFiles", ".cs");
AAMFileManager.MoveDirTo("AAMFiles", "AAMInspect");
//task 3
AAMFileManager.ZipDir("AAMFiles", @"AAMInspect\ZipAAMFiles.zip");
AAMFileManager.UnzipDir(@"AAMInspect\ZipAAMFiles.zip", @"AAMInspect\Unzip");