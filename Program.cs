using EmployeeApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeAppTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using var dbContext = new AppDbContext();
            await dbContext.Database.MigrateAsync();
            await ExecuteCommandAsync(args, dbContext);
        }

        private static async Task ExecuteCommandAsync(string[] args, AppDbContext dbContext)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No command provided.");
                return;
            }

            var command = args[0].ToLowerInvariant();
            switch (command)
            {
                case "set-employee":
                    if (args.Length < 4)
                    {
                        Console.WriteLine("Usage: dotnet run set-employee <id> <name> <salary>");
                        return;
                    }
                    await EmployeeCommands.SetEmployeeAsync(args[1], args[2], args[3], dbContext);
                    break;

                case "get-employee":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Usage: dotnet run get-employee <id>");
                        return;
                    }
                    await EmployeeCommands.GetEmployeeAsync(args[1], dbContext);
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}