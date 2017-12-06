using FluentAssertions;
using NUnit.Framework;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class ControlsContainerTests
    {
        [Test]
        public void AsSerializableObject_HeaderIsBuilded_ObjectIsCorrectlySerialized()
        {
            ControlsContainer container = new Header
            {
                Left = new ControlsBuilder().AddButton(HeaderButton.Prev).AddSeparator(HeaderSeparator.Adjacent)
                    .AddButton(HeaderButton.Next).AddSeparator(HeaderSeparator.Gap).AddButton(HeaderButton.Today),
                Center = new ControlsBuilder().AddTitle(),
                Right = new ControlsBuilder("month,agendaWeek ").AddView(AvailableView.AgendaDay)
            };
            object target = container.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                left = "prev,next today",
                center = "title",
                right = "month,agendaWeek agendaDay"
            });
        }

        [Test]
        public void AsSerializableObject_FooterIsBuilded_ObjectIsCorrectlySerialized()
        {
            ControlsContainer container = new Header
            {
                Center = new ControlsBuilder().AddTitle(),
                Right = new ControlsBuilder().AddView(AvailableView.ListMonth)
            };
            object target = container.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                left = container.Left?.ToString(),
                center = "title",
                right = "listMonth"
            });
        }
    }
}