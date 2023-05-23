using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hashr.Data.Models;

using Spectre.Console.Cli;

namespace Hashr.CLI.Commands
{
    public class HashSettings : CommandSettings
    {
        [CommandOption("--algorithm|-a")]
        public HashAlgorithm Algorithm { get; set; }
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
            

            return 0; // implementing exit codes later
        }
    }
}
