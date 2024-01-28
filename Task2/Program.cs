namespace Task2
{
    internal class Program
    {

        public static void WriteToFile(string fileName)
        {

            var file = new FileInfo(fileName);
            StreamWriter streamWriter = file.CreateText();
            for (int i = 0; i < 10; i++)
            {
                streamWriter.WriteLine($"Random data: {i}");
            }
            streamWriter.Close();
        }

        public static void ReadFile(string fileName)
        {
            var file = new FileInfo(fileName);
            if (file.Exists)
            {
                StreamReader streamReader = file.OpenText();
                while (streamReader.Peek() != -1)
                {
                    string line = streamReader.ReadLine();
                    Console.WriteLine(line);
                }
                streamReader.Close();
            }
            else
            {
                Console.WriteLine("file {0} does not exist", fileName);
            }
        }


        static void Main(string[] args)
        {
            WriteToFile("randomData.txt");
            ReadFile("randomData.txt");
        }
    }
}
