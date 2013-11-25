using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OctoVariables.Commands
{
    public class ImportCommandHandler : ICommandLineHandler
    {
        public void Execute(Command command)
        {

            using (var stream = File.Open(command.FilePath, FileMode.Open))
            {


                using (var reader = new StreamReader(stream))
                {

                    var line = reader.ReadLine();

                    while (!string.IsNullOrEmpty(line))
                    {
                        line = reader.ReadLine();

                    }
                    
                    
                }
            }
        }
    }
}