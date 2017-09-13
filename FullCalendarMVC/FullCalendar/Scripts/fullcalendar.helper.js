(function ($) {
    var fullCalendarParameters = {
        // General Display
        header: { name: 'header', type: 'object' },
        footer: { name: 'footer', type: 'object' },
        isrtl: { name: 'isRTL', type: 'boolean' },
        weekends: { name: 'weekends', type: 'boolean' },
        fixedweekcount: { name: 'fixedWeekCount', type: 'boolean' },
        weeknumbers: { name: 'weekNumbers', type: 'boolean' },
        weeknumberswithindays: { name: 'weekNumbersWithinDays', type: 'boolean' },
        shownoncurrentdates: { name: 'showNonCurrentDates', type: 'boolean' },

        // Agenda Options
        alldayslot: { name: 'allDaySlot', type: 'boolean' },

        // Selection
        selectable: { name: 'selectable', type: 'boolean' },
        selecthelper: { name: 'selectHelper', type: 'boolean' },
        unselectauto: { name: 'unselectAuto', type: 'boolean' }
    }

    $(function () {
        var calendars = $('.fc');
        for (i = 0; i < calendars.length; i++) {
            var calendarObj = {};
            var data = $(calendars[i]).data();
            for (item in data) {
                var calendarParameter = fullCalendarParameters[item.substring(2).toLowerCase()]
                calendarObj[calendarParameter.name] = parseData(data[item], calendarParameter.type);
                $(calendars[i]).removeAttr("data-fc-" + item.substring(2));
            }
            //console.log(calendarObj);
            $(calendars[i]).fullCalendar(calendarObj);
        }
    });

    function parseData(data, type) {
        switch (type) {
            case 'boolean':
                return data;
            case 'object':
                return JSON.parse(data.replace(/\'/g, '"'));
        }        
    }
}(jQuery));