using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ColorPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsDefaultColor_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventColor));
            FullCalendarParameters parameters = new FullCalendarParameters();
            ColorPropertyParser parser = new ColorPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotDefaultColor_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventTextColor));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventTextColor = Color.Gold
            };
            ColorPropertyParser parser = new ColorPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-EventTextColor", "#FFD700");
        }
    }
}