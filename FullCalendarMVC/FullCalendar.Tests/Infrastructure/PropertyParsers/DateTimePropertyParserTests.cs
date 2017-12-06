using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class DateTimePropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsDefaultDate_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DefaultDate));
            FullCalendarParameters parameters = new FullCalendarParameters();
            DateTimePropertyParser parser = new DateTimePropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotDefaultDate_PropertyIsAdded()
        {
            DateTime now = DateTime.Now;
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Now));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Now = now
            };
            DateTimePropertyParser parser = new DateTimePropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Now", now.ToString("MM/dd/yyyy hh:mm:ss"));
        }
    }
}