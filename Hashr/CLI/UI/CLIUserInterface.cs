using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;

namespace Hashr.CLI.UI
{
    public class CLIUserInterface
    {
        public static void Panel(string text, PanelHeader? panelHeader = null)
        {
            AnsiConsole.Write(new Panel(text) { Header = panelHeader, Border = BoxBorder.Heavy });
        }
    }
}
