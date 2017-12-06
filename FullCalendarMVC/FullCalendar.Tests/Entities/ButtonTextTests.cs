using FluentAssertions;
using NUnit.Framework;
using System.Reflection;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class ButtonTextTests
    {
        [Test]
        public void AsSerializableObject_TodayPropertyNotSet_ObjectDoesNotHaveTodayProperty()
        {
            ButtonText buttonText = new ButtonText();
            object target = buttonText.AsSerializableObject();
            PropertyInfo[] properties = target.GetType().GetProperties();
            properties.Should().NotContain(x => x.Name == "today");
        }

        [Test]
        public void AsSerializableObject_ButtonTextIsBuilded_ObjectIsCorrectlySerialized()
        {
            ButtonText buttonText = new ButtonText
            {
                Today = "today",
                Month = "month",
                Week = "week",
                Day = "day"
            };
            object target = buttonText.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                today = "today",
                month = "month",
                week = "week",
                day = "day",
                list = buttonText.List?.ToString()
            });
        }
    }
}