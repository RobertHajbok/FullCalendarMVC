using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class CustomViewPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Views));
            FullCalendarParameters parameters = new FullCalendarParameters();
            CustomViewPropertyParser parser = new CustomViewPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_DictionaryIsEmpty_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Views));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Views = new Dictionary<string, View>()
            };
            CustomViewPropertyParser parser = new CustomViewPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_DictionaryIsNotEmpty_PropertyIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Views));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Views = new Dictionary<string, View>
                {
                    {
                        "agendaFourDay", new View
                        {
                            Type = "agenda",
                            ButtonText = "4 day",
                            Duration = new Duration
                            {
                                Days = 4
                            }
                        }
                    }
                }
            };
            CustomViewPropertyParser parser = new CustomViewPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Views", @"{'agendaFourDay':{'type':'agenda','buttonText':'4 day','titleFormat':null,'visibleRange':null,'dateIncrement':null,'dateAlignment':null,'duration':{'days':4,'weeks':0,'months':0},'dayCount':0}}");
        }
    }
}