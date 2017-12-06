using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class BusinessHoursPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.BusinessHours));
            FullCalendarParameters parameters = new FullCalendarParameters();
            BusinessHoursPropertyParser parser = new BusinessHoursPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ListIsEmpty_TrueIsAddedAsValue()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.BusinessHours));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                BusinessHours = new List<BusinessHour>()
            };
            BusinessHoursPropertyParser parser = new BusinessHoursPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-BusinessHours", "true");
        }

        [Test]
        public void AddPropertyToDictionary_ListIsNotEmpty_ValuesIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.BusinessHours));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                BusinessHours = new List<BusinessHour>
                {
                    new BusinessHour
                    {
                        Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                        Start = TimeSpan.FromHours(10),
                        End = TimeSpan.FromHours(15)
                    }
                }
            };
            BusinessHoursPropertyParser parser = new BusinessHoursPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-BusinessHours", "[{'dow':[4,5],'start':'10:00','end':'15:00'}]");
        }
    }
}