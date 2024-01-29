using System.ComponentModel.DataAnnotations;
using System.IO.Compression;

namespace Task3
{
    internal class Program
    {
        static string SerchFile(string fileName)
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("all available disks:");
            foreach (var drive in drives)
            {
                Console.Write(drive);
            }
            Console.WriteLine();
            Console.WriteLine("enter name of disk you want to search:");
            string disk = Console.ReadLine();
            disk += ":\\";
            string[] files = Directory.GetFiles(disk, fileName);
            if (files.Length > 0)
            {
                return files[0];
            }

            return null;
        }

        static void DisplayFileContent(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
        }

        static void CompressFile(string filePath)
        {
            using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = File.Create(Path.ChangeExtension(filePath, "gz")))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter name of file you want to find:");
            string fileName = Console.ReadLine();
            string filePath = SerchFile(fileName);
            if (filePath != null)
            {
                Console.WriteLine("Do you want to see content of the file? Y/N");
                string response = Console.ReadLine();
                if (response.Trim().ToLower() == "y")
                {
                    DisplayFileContent(filePath);
                }
                Console.WriteLine("Do you want to compress the file? Y/N");
                response = Console.ReadLine();
                if (response.Trim().ToLower() == "y")
                {
                    CompressFile(filePath);
                    Console.WriteLine("Done :)");
                }
            }
            else
            {
                Console.WriteLine("file does not exist");
            }
            
        }
    }
}
