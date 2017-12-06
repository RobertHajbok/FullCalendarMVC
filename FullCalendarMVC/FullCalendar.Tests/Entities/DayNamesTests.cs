using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class DayNamesTests
    {
        [Test]
        public void AsSerializableObject_DayNamesIsBuilded_ObjectIsCorrectlySerialized()
        {
            DayNames dayNames = new DayNames
            {
                Monday = "Mo",
                Tuesday = ""
            };
            object target = dayNames.AsSerializableObject();
            target.ShouldBeEquivalentTo(new List<string>
            {
                "Mo", "", "undefined", "undefined",
                "undefined", "undefined", "undefined"
            });
        }
    }
}