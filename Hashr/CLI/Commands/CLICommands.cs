using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hashr.CLI.UI;
using Hashr.Core.Crypto.Hashing;
using Hashr.Core.Helpers.Extensions;
using Hashr.Data.Models;

using Spectre.Console;
using Spectre.Console.Cli;

namespace Hashr.CLI.Commands
{
    public class HashSettings : CommandSettings
    {
        [CommandOption("--algorithm|-a")]
        public HashAlgorithm Algorithm { get; set; }

        [CommandOption("--hash|-h")]
        public string HashToCompare { get; set; }
    }

    public class FileHashingSettings : HashSettings
    {
        [CommandArgument(0, "<FILE>")]
        public string File { get; set; }
    }

    public class FileHashingCommand : AsyncCommand<FileHashingSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, FileHashingSettings settings)
        {
            string hash = await AnsiConsole.Progress().StartAsync<string>(async (ctx) =>
            {
                return await HashEngine.HashFile(settings, ctx);
            });

            if (!string.IsNullOrEmpty(settings.HashToCompare))
            {
                bool isHashCorrect = hash.Equals(settings.HashToCompare, StringComparison.InvariantCultureIgnoreCase);

                if (isHashCorrect)
                {
                    CLIUserInterface.Panel($"[bold green]{hash}[/]", new PanelHeader("Result", Justify.Left));
                }
                else
                {
                    CLIUserInterface.Panel($"[bold red]{hash}[/]", new PanelHeader("Result", Justify.Left));
                }
            }
            else
            {
                CLIUserInterface.Panel($"[bold]{hash}[/]", new PanelHeader("Result", Justify.Left));
            }
            

            return 0; // implementing exit codes later
        }
    }
}
