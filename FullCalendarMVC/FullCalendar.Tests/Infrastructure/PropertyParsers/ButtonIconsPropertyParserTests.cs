using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ButtonIconsPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsPassed_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ButtonIcons));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ButtonIcons = new
                {
                    prev = "left-single-arrow"
                }
            };
            ButtonIconsPropertyParser parser = new ButtonIconsPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ButtonIcons", "{'prev':'left-single-arrow'}");
        }
    }
}