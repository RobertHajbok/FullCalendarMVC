using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class TimeSpanPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsDefaultTimeSpan_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ScrollTime));
            FullCalendarParameters parameters = new FullCalendarParameters();
            TimeSpanPropertyParser parser = new TimeSpanPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotDefaultTimeSpan_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.MinTime));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                MinTime = TimeSpan.FromHours(10)
            };
            TimeSpanPropertyParser parser = new TimeSpanPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-MinTime", "36000000");
        }
    }
}