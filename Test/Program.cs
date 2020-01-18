using DamaDb.Interface;
using System;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Start().Wait();
        }

        static async Task Start()
        {
            Database db = new Database("clientdb.dama");
            await db.CreateTableAsync()
                .ConfigureAwait(false);

            var exists = System.IO.File.Exists("clientdb.dama");
            if (exists)
                Console.WriteLine("Database file gets created.");
            else
                Console.WriteLine("Database file not exists.");
        }
    }
}
