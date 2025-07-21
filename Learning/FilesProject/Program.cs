using System.Reflection.PortableExecutable;

namespace FilesProject
{
    internal class Program
    {
        const string fileName = @"..\..\..\test.txt";
        const string dirName = @"..\..\..\";
        static void Main(string[] args)
        {
            if (!File.Exists(fileName))
                File.Create(fileName);

            FileInfo fi = new FileInfo(fileName);
            if (!fi.Exists)
                fi.Create();
            else
                Console.WriteLine("{0} {1}",
                    fi.FullName, fi.CreationTime);

            string content = File.ReadAllText(fileName);
            Console.WriteLine(content);

            DirectoryInfo dir = new DirectoryInfo(dirName);
            Console.WriteLine(dir.FullName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (var d in dirs)
                Console.WriteLine(d.Name.ToUpper());

            foreach (var f in dir.GetFiles())
                Console.WriteLine(f.Name.ToLower());

            // c:\folder
            //test.txt
            // c:\folder\test.txt

            Console.WriteLine(Path.Combine(@"c:\folder", "test"));
            Console.WriteLine(Path.GetTempFileName());

            //FileStream fs = new FileStream(fileName, FileMode.Open);
            //fs.Seek(0, SeekOrigin.Begin);
            //fs.Read()
            //fs.Close();
            //fs.Dispose

            /*StreamReader reader = new StreamReader(fileName);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            finally
            {
                reader?.Close(); // reader?.Dispose();
            }*/

            using (StreamReader reader = new StreamReader(fileName))
            { 
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            } //reader.Dispose()

            //StreamWriter writer = new StreamWriter(fileName, true);
            //try {
            //    writer.WriteLine("Строка 1");
            //}
            //finally { writer?.Close(); }
            


        }
    }
}
