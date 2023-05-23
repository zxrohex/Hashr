using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hashr.CLI.Commands;
using Hashr.Core.Helpers.Extensions;

using Org.BouncyCastle.Crypto;

using Spectre.Console;

namespace Hashr.Core.Crypto.Hashing
{
    /* This will not contain the best and cleanest code
     * I will do it later
     * 
     * My focus is on making it feature complete first and I am trying my best
     * to write clean, readable and good code in the first place but I am not perfect
     */

    public class HashEngine
    {
        public static async Task<string> HashFile(FileHashingSettings settings, ProgressContext ctx)
        {
            // yes I know it's not the best cleanest code and I should modularize it, I will do it later

            return await Task.Run(async () =>
            {
                var task = ctx.AddTask($"Hashing {Path.GetFileName(settings.File)} ...");

                IDigest digest = settings.Algorithm.GetDigest();

                using (BufferedStream bs = new BufferedStream(File.OpenRead(settings.File), 8192 * 8192))
                {
                    byte[] buffer = new byte[512];

                    int read;

                    long totalRead = 0;

                    while ((read = await bs.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        totalRead += read;

                        task.Value = (double)((double)totalRead / (double)bs.Length * 100);

                        digest.BlockUpdate(buffer, 0, read);
                    }
                }

                return digest.GetHash();
            });
        }
    }
}
