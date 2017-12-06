using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class DoublePropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsDefaultDouble_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AspectRatio));
            FullCalendarParameters parameters = new FullCalendarParameters();
            DoublePropertyParser parser = new DoublePropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotDefaultDouble_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AspectRatio));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                AspectRatio = 1.23
            };
            DoublePropertyParser parser = new DoublePropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-AspectRatio", "1.23");
        }
    }
}