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

        // List View
        listdayformat: { name: 'listDayFormat', type: 'string' },
        listdayaltformat: { name: 'listDayAltFormat', type: 'string' },
        noeventsmessage: { name: 'noEventsMessage', type: 'string' },

        // Current Date
        defaultdate: { name: 'defaultDate', type: 'moment' },
        nowindicator: { name: 'nowIndicator', type: 'boolean' },

        // Text/Time Customization
        timeformat: { name: 'timeFormat', type: 'string' },
        columnformat: { name: 'columnFormat', type: 'string' },
        titleformat: { name: 'titleFormat', type: 'string' },
        weeknumbertitle: { name: 'weekNumberTitle', type: 'string' },
        displayeventtime: { name: 'displayEventTime', type: 'boolean' },
        displayeventend: { name: 'displayEventEnd', type: 'boolean' },

        // Clicking & Hovering
        navlinks: { name: 'navLinks', type: 'boolean' },
        navlinkdayclick: { name: 'navLinkDayClick', type: 'callback' },
        navlinkweekclick: { name: 'navLinkWeekClick', type: 'callback' },
        dayclick: { name: 'dayClick', type: 'callback' },
        eventclick: { name: 'eventClick', type: 'callback' },
        eventmouseover: { name: 'eventMouseover', type: 'callback' },
        eventmouseout: { name: 'eventMouseout', type: 'callback' },

        // Selection
        selectable: { name: 'selectable', type: 'boolean' },
        selecthelper: { name: 'selectHelper', type: 'boolean' },
        unselectauto: { name: 'unselectAuto', type: 'boolean' },
        selectmindistance: { name: 'selectMinDistance', type: 'integer' },
        selectlongpressdelay: { name: 'selectLongPressDelay', type: 'integer' },

        // Event Data
        events: { name: 'events', type: 'string' },
        eventsources: { name: 'eventSources', type: 'array' },
        alldaydefault: { name: 'allDayDefault', type: 'boolean' },
        startparam: { name: 'startParam', type: 'string' },
        endparam: { name: 'endParam', type: 'string' },
        lazyfetching: { name: 'lazyFetching', type: 'boolean' },
        defaulttimedeventduration: { name: 'defaultTimedEventDuration', type: 'duration' },
        defaultalldayeventduration: { name: 'defaultAllDayEventDuration', type: 'duration' },
        forceeventduration: { name: 'forceEventDuration', type: 'boolean' },

        // Event Rendering
        eventcolor: { name: 'eventColor', type: 'string' },
        eventbackgroundcolor: { name: 'eventBackgroundColor', type: 'string' },
        eventbordercolor: { name: 'eventBorderColor', type: 'string' },
        eventtextcolor: { name: 'eventTextColor', type: 'string' },
        nextdaythreshold: { name: 'nextDayThreshold', type: 'duration' },
        eventrenderwait: { name: 'eventRenderWait', type: 'integer' },

        // Event Dragging & Resizing
        editable: { name: 'editable', type: 'boolean' },
        eventstarteditable: { name: 'eventStartEditable', type: 'boolean' },
        eventdurationeditable: { name: 'eventDurationEditable', type: 'boolean' },
        dragrevertduration: { name: 'dragRevertDuration', type: 'integer' },
        dragopacity: { name: 'dragOpacity', type: 'float' },
        dragscroll: { name: 'dragScroll', type: 'boolean' },
        longpressdelay: { name: 'longPressDelay', type: 'integer' },
        eventlongpressdelay: { name: 'eventLongPressDelay', type: 'integer' }
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
                return data;
            case 'duration':
                return moment.duration(data);
            case 'moment':
                return moment(data, "MM/DD/YYYY hh:mm:ss");
            case 'array':
            case 'object':
                return $.isArray(data) ? data : JSON.parse(data.replace(/\'/g, '"'));
            case 'callback':
                try {
                    return eval('(' + JSON.parse(data.replace(/\'/g, '"')).function + ')');
                }
                catch (e) {
                    console.error(e);
                    return null;
                }
        }
    }
}(jQuery));