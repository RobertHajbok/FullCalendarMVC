using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class DayOfWeekPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsPassed_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.FirstDay));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                FirstDay = DayOfWeek.Monday
            };
            DayOfWeekPropertyParser parser = new DayOfWeekPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-FirstDay", "1");
        }
    }
}