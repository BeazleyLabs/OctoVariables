using System;
using System.Text.RegularExpressions;

namespace OctoVariables.Commands
{
    public class VariableData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Environment { get; set; }
        public string Role { get; set; }
        public string Step { get; set; }

        public static VariableData Parse(string value)
        {

            var regex = new Regex("(?:,|^)([^\",]+|\"(?:[^\"]|\"\")*\")?");

            
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }


            var matches = regex.Matches(value);

            
            
            var data = new VariableData();

            data.Name = matches[0].Groups[1].Value;
            data.Value = matches[1].Value;
            data.Environment = matches[2].Value;
            data.Role = matches[3].Value;
            data.Step = matches[4].Value;
            
            return data;
        }

        
    }
}