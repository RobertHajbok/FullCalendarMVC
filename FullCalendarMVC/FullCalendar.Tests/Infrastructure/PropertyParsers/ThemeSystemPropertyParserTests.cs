using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ThemeSystemPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsPassed_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ThemeSystem));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ThemeSystem = ThemeSystem.Bootstrap3
            };
            ThemeSystemPropertyParser parser = new ThemeSystemPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ThemeSystem", "bootstrap3");
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsJqueryUI_PropertyIsCorrectlySet()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ThemeSystem));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ThemeSystem = ThemeSystem.JqueryUI
            };
            ThemeSystemPropertyParser parser = new ThemeSystemPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ThemeSystem", "jquery-ui");
        }
    }
}