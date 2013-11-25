using System;

namespace OctoVariables.Commands
{
    public class CommandHandlerFactory
    {
        public ICommandLineHandler Create(Command options)
        {
            if (options.Name.Equals("Export", StringComparison.InvariantCultureIgnoreCase))
            {
                return new ExportCommandHandler();
            }

            return new ImportCommandHandler();
        }
    }
}