using FluentAssertions;
using NUnit.Framework;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class ControlsBuilderTests
    {
        [Test]
        public void AddSeparator_HeaderSeparatorAdded_StringIsCorrectlyBuilded()
        {
            ControlsBuilder target = new ControlsBuilder();
            target.AddSeparator(HeaderSeparator.Gap);
            target.AddSeparator(HeaderSeparator.Adjacent);
            target.ToString().Should().Be(" ,");
        }

        [Test]
        public void AddTitle_TitleAdded_StringIsCorrectlyBuilded()
        {
            ControlsBuilder target = new ControlsBuilder();
            target.AddTitle();
            target.ToString().Should().Be("title");
        }

        [Test]
        public void AddButton_HeaderButtonAdded_StringIsCorrectlyBuilded()
        {
            ControlsBuilder target = new ControlsBuilder();
            target.AddButton(HeaderButton.Prev);
            target.AddButton(HeaderButton.Next);
            target.ToString().Should().Be("prevnext");
        }

        [Test]
        public void AddView_ViewAdded_StringIsCorrectlyBuilded()
        {
            ControlsBuilder target = new ControlsBuilder();
            target.AddView(AvailableView.Month);
            target.AddView(GenericView.Agenda);
            target.ToString().Should().Be("monthagenda");
        }
    }
}