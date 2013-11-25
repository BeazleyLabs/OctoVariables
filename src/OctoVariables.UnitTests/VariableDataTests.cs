using System;
using FluentAssertions;
using OctoVariables.Commands;
using Xunit;

namespace OctoVariables.UnitTests
{
    public class VariableDataTests
    {
        [Fact]
        public void ParseWithNullThrows()
        {
            Assert.Throws<ArgumentNullException>(() => VariableData.Parse(null));
        }

        [Fact]
        public void ParseWithCsvValueParsesCorrecty()
        {
            var expected = new VariableData
            {
                Environment = "Environment",
                Name = "Name",
                Role = "Role",
                Step = "Step",
                Value = "Value"
            };

            var actual = VariableData.Parse("Name,Value,Environment,Role,Step");

            actual.ShouldHave().AllProperties().EqualTo(expected);
            
        }


        [Fact]
        public void ParseWithCsvValuesHavingQuotesParsesCorrecty()
        {
            var expected = new VariableData
            {
                Environment = "Environment",
                Name = "Name",
                Role = "Role",
                Step = "Step",
                Value = "Value"
            };

            var actual = VariableData.Parse("\"Name\",\"Value\",\"Environment\",\"Role,\"Step\"");

            actual.ShouldHave().AllProperties().EqualTo(expected);

        }
    }
}