using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class UnitPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Height));
            FullCalendarParameters parameters = new FullCalendarParameters();
            UnitPropertyParser parser = new UnitPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsSetAsPixels_PropertyIsFormattedAccordingly()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ContentHeight));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ContentHeight = Unit.Pixel(300)
            };
            UnitPropertyParser parser = new UnitPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ContentHeight", "300px");
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsSetFunction_PropertyIsAddedAsString()
        {
            string function = "function() { alert(''); }";
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ContentHeight));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ContentHeight = Unit.Function(function)
            };
            UnitPropertyParser parser = new UnitPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ContentHeight", function);
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsSetAsAuto_PropertyIsFormattedAccordingly()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ContentHeight));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ContentHeight = Unit.Auto()
            };
            UnitPropertyParser parser = new UnitPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ContentHeight", "auto");
        }
    }
}