(function ($) {
    var fullCalendarParameters = {
        isrtl: {
            name: 'isRTL',
            type: 'boolean'
        },
        fixedweekcount: {
            name: 'fixedWeekCount',
            type: 'boolean'
        }
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
            $(calendars[i]).fullCalendar(calendarObj);
        }
    });
}(jQuery));