using FluentAssertions;
using FullCalendar.Serialization.SerializableObjects;
using FullCalendar.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FullCalendar.Serialization.Tests
{
    [TestFixture]
    public class NullPropertiesConverterTests
    {
        [Test]
        public void Deserialize_UsedOnAJavaScriptSerializer_NotImplementedExceptionShouldBeThrown()
        {
            NullPropertiesConverter nullPropertiesConverter = new NullPropertiesConverter();
            Action target = () =>
            {
                nullPropertiesConverter.Deserialize(null, typeof(int), null);
            };
            target.ShouldThrow<NotImplementedException>();
        }

        [Test]
        public void Serialize_When_IntegerPropertyIsZero_PropertyIsNotAddedToSerialization()
        {
            NullPropertiesConverter nullPropertiesConverter = new NullPropertiesConverter();
            Duration duration = new Duration
            {
                Days = 1,
                Weeks = 0,
                Months = 2
            };
            IDictionary<string, object> target = nullPropertiesConverter.Serialize(duration, null);
            target.Should().Contain("Days", 1);
            target.Should().Contain("Months", 2);
            target.Should().NotContainKey("Weeks");
        }

        [Test]
        public void Serialize_When_PropertyDecoratedWithScriptIgnoreAttribute_PropertyIsNotAddedToSerialization()
        {
            NullPropertiesConverter nullPropertiesConverter = new NullPropertiesConverter();
            ScriptIgnoreAttributeMock scriptIgnoreAttributeMock = new ScriptIgnoreAttributeMock
            {
                Id = 32
            };
            IDictionary<string, object> target = nullPropertiesConverter.Serialize(scriptIgnoreAttributeMock, null);
            target.Should().BeEmpty();
        }

        [Test]
        public void Serialize_When_PropertyIsNull_PropertyIsNotAddedToSerialization()
        {
            NullPropertiesConverter nullPropertiesConverter = new NullPropertiesConverter();
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventRenderWait = null
            };
            IDictionary<string, object> target = nullPropertiesConverter.Serialize(parameters, null);
            target.Should().NotContainKey("EventRenderWait");
        }

        [Test]
        public void Serialize_When_PropertiesAreNotNull_AllOfThemAreAddedToSerialization()
        {
            NullPropertiesConverter nullPropertiesConverter = new NullPropertiesConverter();
            SerializableValidRange validRange = new SerializableValidRange
            {
                start = "1:00",
                end = "2:00"
            };
            IDictionary<string, object> target = nullPropertiesConverter.Serialize(validRange, null);
            target.Should().Contain("start", "1:00");
            target.Should().Contain("end", "2:00");
        }
    }
}