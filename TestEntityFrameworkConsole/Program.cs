using System;
using Entities.Contexts;
using Entities.Models;


namespace TestEntityFrameworkConsole
{
    class Program
    {
        #region Implementation
        static void Main(string[] args)
        {
            var context = new EntityContext();
            context.Files.Add(new File { Name = "File 1" });
            context.Files.Add(new File { Name = "File 2" });
            context.Files.Add(new File { Name = "File 3" });
            context.Files.Add(new File { Name = "File 4" });
            context.SaveChanges();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        #endregion
    }
}