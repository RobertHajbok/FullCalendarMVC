using FluentAssertions;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class FullCalendarHelperTests
    {
        [Test]
        public void FullCalendar_FullParametersNotSet_DefaultHtmlShouldBeCorrectlyBuilt()
        {
            HtmlHelper htmlHelper = null;
            IHtmlString target = htmlHelper.FullCalendar();
            target.ToHtmlString().Should().Be("<div   class=\"fc \" data-fc-ButtonIcons=\"{'prev':'left-single-arrow','next':'right-single-arrow','prevYear':'left-double-arrow','nextYear':'right-double-arrow'}\" data-fc-ThemeSystem=\"standard\" data-fc-ThemeButtonIcons=\"{'prev':'circle-triangle-w','next':'circle-triangle-e','prevYear':'seek-prev','nextYear':'seek-next'}\" data-fc-BootstrapGlyphicons=\"{'close':'glyphicon-remove','prev':'glyphicon-chevron-left','next':'glyphicon-chevron-right','prevYear':'glyphicon-backward','nextYear':'glyphicon-forward'}\" data-fc-FirstDay=\"0\" data-fc-IsRTL=\"false\" data-fc-Weekends=\"true\" data-fc-FixedWeekCount=\"true\" data-fc-WeekNumbers=\"false\" data-fc-WeekNumbersWithinDays=\"false\" data-fc-ShowNonCurrentDates=\"true\" data-fc-HandleWindowResize=\"true\" data-fc-AllDaySlot=\"true\" data-fc-SlotEventOverlap=\"true\" data-fc-NowIndicator=\"false\" data-fc-NavLinks=\"false\" data-fc-Selectable=\"false\" data-fc-SelectHelper=\"false\" data-fc-UnselectAuto=\"true\" data-fc-LazyFetching=\"true\" data-fc-ForceEventDuration=\"false\" data-fc-Editable=\"false\" data-fc-EventStartEditable=\"true\" data-fc-EventDurationEditable=\"true\" data-fc-DragOpacity=\"0.75\" data-fc-DragScroll=\"true\" data-fc-Droppable=\"false\"></div>");
        }

        [Test]
        public void FullCalendar_NameIsSetInCalendarParameters_HtmlShouldContainIdAndName()
        {
            HtmlHelper htmlHelper = null;
            IHtmlString target = htmlHelper.FullCalendar(settings =>
            {
                settings.Name = "test";
            });
            target.ToHtmlString().Should().Contain("id='test'");
            target.ToHtmlString().Should().Contain("name='test'");
        }
    }
}