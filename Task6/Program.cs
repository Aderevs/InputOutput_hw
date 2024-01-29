namespace Task6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("all available disks:");
            foreach (var drive in drives)
            {
                Console.Write(drive);
            }
            Console.WriteLine();
            Console.WriteLine("enter name of disk you want to create folders:");
            string disk = Console.ReadLine();
            disk += ":\\";
            for(int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory(disk + $"Folder_{i}");
            }
            Console.WriteLine("folders was created");
            for (int i = 0; i < 100; i++)
            {
                Directory.Delete(disk + $"Folder_{i}");
            }
            Console.WriteLine("folders was deleted");
        }
    }
}
