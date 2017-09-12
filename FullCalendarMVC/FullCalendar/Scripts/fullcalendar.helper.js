(function ($) {
    var fullCalendarParameters = {
        // General Display
        isrtl: { name: 'isRTL', type: 'boolean' },
        weekends: { name: 'weekends', type: 'boolean' },
        fixedweekcount: { name: 'fixedWeekCount', type: 'boolean' },
        weeknumbers: { name: 'weekNumbers', type: 'boolean' },
        weeknumberswithindays: { name: 'weekNumbersWithinDays', type: 'boolean' },
        shownoncurrentdates: { name: 'showNonCurrentDates', type: 'boolean' },

        // Agenda Options
        alldayslot: { name: 'allDaySlot', type: 'boolean' }
    }

    $(function () {
        var calendars = $('.fc');
        for (i = 0; i < calendars.length; i++) {
            var calendarObj = {};
            var data = $(calendars[i]).data();
            for (item in data) {
                calendarObj[fullCalendarParameters[item.substring(2).toLowerCase()].name] = data[item];
                $(calendars[i]).removeAttr("data-fc-" + item.substring(2));
            }
            //console.log(calendarObj);
            $(calendars[i]).fullCalendar(calendarObj);
        }
    });
}(jQuery));