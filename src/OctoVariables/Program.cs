using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using OctoVariables.Commands;

namespace OctoVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new Command();
            bool isHelp = args.Any(x => x == "-?");
            var success = Parser.Default.ParseArguments(args, command);

            if (!success || isHelp)
            {
                if (!isHelp && args.Length > 0)
                    Console.Error.WriteLine("error parsing command line");
            
            }


            var factory = new CommandHandlerFactory();
            var commandHandler = factory.Create(command);
            commandHandler.Execute(command);
            
        }
    }

}
