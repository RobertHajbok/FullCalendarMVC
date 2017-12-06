using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class FloatPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsPassed_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DragOpacity));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                DragOpacity = 0.6F
            };
            FloatPropertyParser parser = new FloatPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-DragOpacity", "0.6");
        }
    }
}