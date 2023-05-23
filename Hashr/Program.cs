using Hashr.CLI.Commands;

using Spectre.Console.Cli;

namespace Hashr
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var app = new CommandApp();

            app.Configure(c =>
            {
                c.AddBranch("hash", h =>
                {
                    h.AddCommand<FileHashingCommand>("file");
                });
            });

            await app.RunAsync(args);
        }
    }
}