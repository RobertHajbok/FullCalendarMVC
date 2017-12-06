using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class EnumPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DateAlignment));
            FullCalendarParameters parameters = new FullCalendarParameters();
            EnumPropertyParser parser = new EnumPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DateAlignment));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                DateAlignment = DateAlignment.Month
            };
            EnumPropertyParser parser = new EnumPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-DateAlignment", "month");
        }
    }
}