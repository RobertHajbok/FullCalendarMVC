using FullCalendar.Infrastructure.PropertyParsers;
using FullCalendar.Interfaces;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Abstract.Tests
{
    [TestFixture]
    public class PropertyParserFactoryTests
    {
        #region Google Calendar

        [Test]
        public void GetPropertyParser_GoogleCalendarApiKeyIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.GoogleCalendarApiKey));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        #endregion

        #region General Display

        [Test]
        public void GetPropertyParser_HeaderIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Header));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_FooterIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Footer));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_CustomButtonsIsSent_CustomButtonsPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.CustomButtons));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(CustomButtonsPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ButtonIconsIsSent_ButtonIconsPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ButtonIcons));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ButtonIconsPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ThemeSystemIsSent_ThemeSystemPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ThemeSystem));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ThemeSystemPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ThemeButtonIconsIsSent_ButtonIconsPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ThemeButtonIcons));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ButtonIconsPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_BootstrapGlyphiconsIconsIsSent_ButtonIconsPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.BootstrapGlyphicons));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ButtonIconsPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_FirstDayIsSent_DayOfWeekPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.FirstDay));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(DayOfWeekPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_IsRtlIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.IsRTL));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WeekendsIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Weekends));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_HiddenDaysIsSent_ArrayPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.HiddenDays));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ArrayPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_FixedWeekCountIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.FixedWeekCount));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WeekNumbersIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.WeekNumbers));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WeekNumbersWithinDaysIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.WeekNumbersWithinDays));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WeekNumberCalculationIsSent_FunctionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.WeekNumberCalculation));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(FunctionPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_BusinessHoursIsSent_BusinessHoursPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.BusinessHours));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BusinessHoursPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ShowNonCurrentDatesIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ShowNonCurrentDates));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_HeightIsSent_UnitPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Height));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(UnitPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ContentHeightIsSent_UnitPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ContentHeight));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(UnitPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_AspectRatioIsSent_DoublePropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AspectRatio));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(DoublePropertyParser)));
        }

        [Test]
        public void GetPropertyParser_HandleWindowResizeIsSent_DoublePropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.HandleWindowResize));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WindowResizeDelayIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.WindowResizeDelay));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventLimitIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimit));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventLimitClickIsSent_FunctionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimitClick));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(FunctionPropertyParser)));
        }

        #endregion

        #region Timezone

        [Test]
        public void GetPropertyParser_TimezoneIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Timezone));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_NowIsSent_DateTimePropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Now));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(DateTimePropertyParser)));
        }

        #endregion

        #region Views

        [Test]
        public void GetPropertyParser_ViewsIsSent_CustomViewPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Views));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(CustomViewPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DefaultViewIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DefaultView));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        #endregion

        #region Agenda Options

        [Test]
        public void GetPropertyParser_AllDaySlotIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AllDaySlot));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_AllDayTextIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AllDayText));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SlotDurationIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SlotDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SlotLabelFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SlotLabelFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SlotLabelIntervalIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SlotLabelInterval));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SnapDurationIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SnapDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ScrollTimeIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ScrollTime));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_MinTimeIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.MinTime));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_MaxTimeIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.MaxTime));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SlotEventOverlapIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SlotEventOverlap));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        #endregion

        #region List View

        [Test]
        public void GetPropertyParser_ListDayFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ListDayFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ListDayAltFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ListDayAltFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_NoEventsMessageIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.NoEventsMessage));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        #endregion

        #region Current Date

        [Test]
        public void GetPropertyParser_DefaultDateIsSent_DateTimePropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DefaultDate));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(DateTimePropertyParser)));
        }

        [Test]
        public void GetPropertyParser_NowIndicatorIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.NowIndicator));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_VisibleRangeIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.VisibleRange));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ValidRangeIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ValidRange));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DateIncrementIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DateIncrement));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DateAlignmentIsSent_EnumPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DateAlignment));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(EnumPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DurationIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Duration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DayCountIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DayCount));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        #endregion

        #region Text/Time Customization

        [Test]
        public void GetPropertyParser_LocaleIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Locale));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_TimeFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.TimeFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ColumnFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ColumnFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_TitleFormatIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.TitleFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ButtonTextIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ButtonText));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_MonthNamesIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.MonthNames));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_MonthNamesShortIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.MonthNamesShort));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DayNamesIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DayNames));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DayNamesShortIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DayNamesShort));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_WeekNumberTitleIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.WeekNumberTitle));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DisplayEventTimeIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DisplayEventTime));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DisplayEventEndIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DisplayEventEnd));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventLimitTextIsSent_FunctionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimitText));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(FunctionPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DayPopoverFormatIsSent_FunctionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DayPopoverFormat));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        #endregion

        #region Clicking & Hovering

        [Test]
        public void GetPropertyParser_NavLinksIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.NavLinks));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        #endregion

        #region Selection

        [Test]
        public void GetPropertyParser_SelectableIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Selectable));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SelectHelperIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SelectHelper));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_UnselectAutoIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.UnselectAuto));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_UnselectCancelIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.UnselectCancel));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SelectOverlapIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SelectOverlap));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SelectConstraintIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SelectConstraint));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SelectMinDistanceIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SelectMinDistance));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_SelectLongPressDelayIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.SelectLongPressDelay));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        #endregion

        #region Event Data

        [Test]
        public void GetPropertyParser_EventsIsSent_EventCollectionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(EventCollectionPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventSourcesIsSent_EventSourcesPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventSources));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(EventSourcesPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_AllDayDefaultIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.AllDayDefault));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_StartParamIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.StartParam));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EndParamIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EndParam));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_TimezoneParamIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.TimezoneParam));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_LazyFetchingIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.LazyFetching));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DefaultTimedEventDurationIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DefaultTimedEventDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DefaultAllDayEventDurationIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DefaultAllDayEventDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_ForceEventDurationIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ForceEventDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        #endregion

        #region Event Rendering

        [Test]
        public void GetPropertyParser_EventColorIsSent_ColorPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventColor));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ColorPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventBackgroundColorIsSent_ColorPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventBackgroundColor));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ColorPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventBorderColorIsSent_ColorPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventBorderColor));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ColorPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventTextColorIsSent_ColorPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventTextColor));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ColorPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_NextDayThresholdIsSent_TimeSpanPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.NextDayThreshold));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(TimeSpanPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventOrderIsSent_ArrayPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventOrder));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ArrayPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventRenderWaitIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventRenderWait));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        #endregion

        #region Event Dragging & Resizing

        [Test]
        public void GetPropertyParser_EditableIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Editable));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventStartEditableIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventStartEditable));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventDurationEditableIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventDurationEditable));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DragRevertDurationIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DragRevertDuration));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DragOpacityIsSent_FloatPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DragOpacity));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(FloatPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DragScrollIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DragScroll));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventOverlapIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventOverlap));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventConstraintIsSent_ObjectPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventConstraint));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ObjectPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_LongPressDelayIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.LongPressDelay));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_EventLongPressDelayIsSent_IntegerPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLongPressDelay));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(IntegerPropertyParser)));
        }

        #endregion

        #region Dropping External Elements

        [Test]
        public void GetPropertyParser_DroppableIsSent_BoolPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Droppable));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(BoolPropertyParser)));
        }

        [Test]
        public void GetPropertyParser_DropAcceptIsSent_FunctionPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DropAccept));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(FunctionPropertyParser)));
        }

        #endregion


        [Test]
        public void GetPropertyParser_NameIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Name));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }

        [Test]
        public void GetPropertyParserCssClassIsSent_StringPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.CssClass));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(StringPropertyParser)));
        }


        [Test]
        public void GetPropertyParser_ClientSideEventsIsSent_ClientSideEventsPropertyParserIsCreated()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ClientSideEvents));
            IPropertyParser propertyParser = PropertyParserFactory.GetPropertyParser(property);
            Assert.That(propertyParser, Is.TypeOf(typeof(ClientSideEventsPropertyParser)));
        }
    }
}