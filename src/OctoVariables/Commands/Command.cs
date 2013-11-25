using CommandLine;

namespace OctoVariables.Commands
{
    public class Command : CommandOption
    {

        [Option('c', "command", Required = true, HelpText = "The command to execute Import / Export ")]
        public string Name { get; set; }
        
        [Option('s', "server", Required = true, HelpText = "Octopus server url")]
        public string Server { get; set; }

        [Option('a', "apiKey", Required = true, HelpText = "Api key to authenticate with. You can find it in your Octopus user profile")]
        public string ApiKey { get; set; }

        [Option('p', "project", Required = true, HelpText = "Name of project containing the variables")]
        public string ProjectName { get; set; }

        [Option('f', "file", Required = true, HelpText = "Path to csv file that contains the variables")]
        public string FilePath { get; set; }

        [HelpOption('?', "help")]
        public string GetTheHelp()
        {
            return GetHelp();
        }

    }
}