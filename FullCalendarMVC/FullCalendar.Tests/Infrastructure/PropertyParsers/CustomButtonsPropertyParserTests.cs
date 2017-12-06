using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class CustomButtonsPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.CustomButtons));
            FullCalendarParameters parameters = new FullCalendarParameters();
            CustomButtonsPropertyParser parser = new CustomButtonsPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_PropertyIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.CustomButtons));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                CustomButtons = new Dictionary<string, CustomButton>
                {
                    {
                        "myCustomButton", new CustomButton
                        {
                            Text = "custom!",
                            Click = @"function() {
                                alert('clicked the custom button!');
                            }",
                            Icon = false
                        }
                    }
                }
            };
            CustomButtonsPropertyParser parser = new CustomButtonsPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-CustomButtons", @"{'myCustomButton':{'text':'custom!','click':'function() {\r\n                                alert(\u0027clicked the custom button!\u0027);\r\n                            }','icon':false,'themeIcon':null,'bootstrapGlyphicon':null}}");
        }
    }
}