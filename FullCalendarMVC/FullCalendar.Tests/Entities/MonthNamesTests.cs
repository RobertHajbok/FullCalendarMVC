using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class MonthNamesTests
    {
        [Test]
        public void AsSerializableObject_MonthNamesIsBuilded_ObjectIsCorrectlySerialized()
        {
            MonthNames monthNames = new MonthNames
            {
                November = "No",
                December = ""
            };
            object target = monthNames.AsSerializableObject();
            target.ShouldBeEquivalentTo(new List<string>
            {
                "undefined", "undefined", "undefined", "undefined",
                "undefined", "undefined", "undefined", "undefined",
                "undefined", "undefined", "No", ""
            });
        }
    }
}