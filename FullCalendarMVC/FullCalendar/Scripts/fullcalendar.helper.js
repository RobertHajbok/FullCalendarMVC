(function ($) {
    var fullCalendarParameters = {
        // General Display
        header: { name: 'header', type: 'object' },
        footer: { name: 'footer', type: 'object' },
        firstday: { name: 'firstDay', type: 'integer' },
        isrtl: { name: 'isRTL', type: 'boolean' },
        weekends: { name: 'weekends', type: 'boolean' },
        hiddendays: { name: 'hiddenDays', type: 'array' },
        fixedweekcount: { name: 'fixedWeekCount', type: 'boolean' },
        weeknumbers: { name: 'weekNumbers', type: 'boolean' },
        weeknumberswithindays: { name: 'weekNumbersWithinDays', type: 'boolean' },
        shownoncurrentdates: { name: 'showNonCurrentDates', type: 'boolean' },
        aspectratio: { name: 'aspectRatio', type: 'float' },
        windowresizedelay: { name: 'windowResizeDelay', type: 'integer' },

        // Timezone
        now: { name: 'now', type: 'moment' },

        // Views
        defaultview: { name: 'defaultView', type: 'string' },

        // Agenda Options
        alldayslot: { name: 'allDaySlot', type: 'boolean' },
        alldaytext: { name: 'allDayText', type: 'string' },
        slotduration: { name: 'slotDuration', type: 'duration' },
        slotlabelformat: { name: 'slotLabelFormat', type: 'string' },
        slotlabelinterval: { name: 'slotLabelInterval', type: 'duration' },
        snapduration: { name: 'snapDuration', type: 'duration' },
        scrolltime: { name: 'scrollTime', type: 'duration' },
        mintime: { name: 'minTime', type: 'duration' },
        maxtime: { name: 'maxTime', type: 'duration' },
        sloteventoverlap: { name: 'slotEventOverlap', type: 'boolean' },
        handlewindowresize: { name: 'handleWindowResize', type: 'boolean' },

        // Selection
        selectable: { name: 'selectable', type: 'boolean' },
        selecthelper: { name: 'selectHelper', type: 'boolean' },
        unselectauto: { name: 'unselectAuto', type: 'boolean' },

        // Event Data
        events: { name: 'events', type: 'string' },

        // Event Dragging & Resizing
        editable: { name: 'editable', type: 'boolean' }
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
            case 'string':
            case 'integer':
            case 'float':
            case 'array':
                return data;
            case 'duration':            
                return moment.duration(data);
            case 'moment':
                return moment(data, "MM/DD/YYYY hh:mm:ss");
            case 'object':
                return JSON.parse(data.replace(/\'/g, '"'));
        }
    }
}(jQuery));