using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using OctoVariables.Octopus;
using Environment = OctoVariables.Octopus.Environment;

namespace OctoVariables.Commands
{
    public class ExportCommandHandler : ICommandLineHandler
    {
        public void Execute(Command command)
        {
            var client = new HttpClient { BaseAddress = new Uri(command.Server) };

            client.DefaultRequestHeaders.Add("X-Octopus-ApiKey", command.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var api = client.GetResource<Api>("/api");
            var projects = client.GetResource<IEnumerable<Project>>(api.Links.Projects);
            var project = projects.FirstOrDefault(x => x.Name.Equals(command.ProjectName, StringComparison.InvariantCultureIgnoreCase));
            var variables = client.GetResource<IEnumerable<Variable>>(project.Links.Variables);
            var environmentLookup = client.GetResource<IEnumerable<Environment>>(api.Links.Environments).ToDictionary(x=> x.Id);
            
            
            var csv = new StringBuilder();

            const string format = "\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"";

            csv.AppendLine("Name,Value,Environment,Role,Step");
            
            foreach (var variable in variables)
            {
                var data = new VariableData();
                data.Name = variable.Name;
                data.Value = variable.Value;
                data.Environment = !string.IsNullOrEmpty(variable.EnvironmentId)  ? environmentLookup[variable.EnvironmentId].Name : string.Empty;
                data.Role = variable.Role;
                data.Step = string.Empty;

                csv.AppendFormat(format, data.Name, data.Value, data.Environment, data.Role, data.Step);
                csv.AppendLine();

            }

            var content = csv.ToString();

            File.WriteAllText(command.FilePath, content, Encoding.UTF8);
            

        }
    }


    
}