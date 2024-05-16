using System;
using System.IO;

namespace DirectoryDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] directories = { };
            var directory = @"C:\Users\Nwachukwu\Desktop\DeleteDirectory";

            try
            {
                if (Directory.Exists(directory))
                {
                  directories =   Directory.GetDirectories(directory);
                }
            }
            catch (Exception ex)
            {

                var error = new Exception("File was not Found" + ex.Message.ToString());
            }

            foreach (var dir in directories)
            {
                Console.WriteLine($"List of directories before deleting:   {dir} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            //Directory.Delete(directories[0],true);
            directories = Directory.GetDirectories(directory);

            foreach (var dir in directories)
            {
                if(dir.Length > 0)
                {
                    Console.WriteLine("List of directories After deleting:   " + dir);
                }
                else
                {
                    Console.WriteLine("DeleteDirectory Is Empty   " + dir);
                }
            }

            Console.Read();
        }
    }
}
