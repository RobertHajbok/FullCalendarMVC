(function ($) {
    var fullCalendarParameters = {
        // General Display
        header: { name: 'header', type: 'object' },
        footer: { name: 'footer', type: 'object' },
        custombuttons: { name: 'customButtons', type: 'custom' },
        buttonicons: { name: 'buttonIcons', type: 'boolean/object' },
        themesystem: { name: 'themeSystem', type: 'string' },
        themebuttonicons: { name: 'themeButtonIcons', type: 'boolean/object' },
        bootstrapglyphicons: { name: 'bootstrapGlyphicons', type: 'boolean/object' },
        firstday: { name: 'firstDay', type: 'integer' },
        isrtl: { name: 'isRTL', type: 'boolean' },
        weekends: { name: 'weekends', type: 'boolean' },
        hiddendays: { name: 'hiddenDays', type: 'array' },
        fixedweekcount: { name: 'fixedWeekCount', type: 'boolean' },
        weeknumbers: { name: 'weekNumbers', type: 'boolean' },
        weeknumberswithindays: { name: 'weekNumbersWithinDays', type: 'boolean' },
        weeknumbercalculation: { name: 'weekNumberCalculation', type: 'function/string' },
        businesshours: { name: 'businessHours', type: 'boolean/object' },
        shownoncurrentdates: { name: 'showNonCurrentDates', type: 'boolean' },
        height: { name: 'height', type: 'custom' },
        contentheight: { name: 'contentHeight', type: 'custom' },
        aspectratio: { name: 'aspectRatio', type: 'float' },
        windowresizedelay: { name: 'windowResizeDelay', type: 'integer' },
        eventlimit: { name: 'eventLimit', type: 'integer/boolean' },
        eventlimitclick: { name: 'eventLimitClick', type: 'function/string' },
        viewrender: { name: 'viewRender', type: 'callback' },
        viewdestroy: { name: 'viewDestroy', type: 'callback' },
        dayrender: { name: 'dayRender', type: 'callback' },
        windowresize: { name: 'windowResize', type: 'callback' },

        // Timezone
        timezone: { name: 'timezone', type: 'string' },
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
        locale: { name: 'locale', type: 'string' },
        timeformat: { name: 'timeFormat', type: 'string' },
        columnformat: { name: 'columnFormat', type: 'string' },
        titleformat: { name: 'titleFormat', type: 'string' },
        buttontext: { name: 'buttonText', type: 'object' },
        monthnames: { name: 'monthNames', type: 'array' },
        monthnamesshort: { name: 'monthNamesShort', type: 'array' },
        daynames: { name: 'dayNames', type: 'array' },
        daynamesshort: { name: 'dayNamesShort', type: 'array' },
        weeknumbertitle: { name: 'weekNumberTitle', type: 'string' },
        displayeventtime: { name: 'displayEventTime', type: 'boolean' },
        displayeventend: { name: 'displayEventEnd', type: 'boolean' },
        eventlimittext: { name: 'eventLimitText', type: 'function/string' }, 
        daypopoverformat: { name: 'dayPopoverFormat', type: 'string' }, 

        // Clicking & Hovering
        navlinks: { name: 'navLinks', type: 'boolean' },
        navlinkdayclick: { name: 'navLinkDayClick', type: 'callback/string' },
        navlinkweekclick: { name: 'navLinkWeekClick', type: 'callback/string' },
        dayclick: { name: 'dayClick', type: 'callback' },
        eventclick: { name: 'eventClick', type: 'callback' },
        eventmouseover: { name: 'eventMouseover', type: 'callback' },
        eventmouseout: { name: 'eventMouseout', type: 'callback' },

        // Selection
        selectable: { name: 'selectable', type: 'boolean' },
        selecthelper: { name: 'selectHelper', type: 'boolean' },
        unselectauto: { name: 'unselectAuto', type: 'boolean' },
        unselectcancel: { name: 'unselectCancel', type: 'string' },
        selectoverlap: { name: 'selectOverlap', type: 'boolean/function' }, 
        selectconstraint: { name: 'selectConstraint', type: 'object' }, 
        selectallow: { name: 'selectAllow', type: 'callback' }, 
        selectmindistance: { name: 'selectMinDistance', type: 'integer' },
        selectlongpressdelay: { name: 'selectLongPressDelay', type: 'integer' },
        select: { name: 'select', type: 'callback' },
        unselect: { name: 'unselect', type: 'callback' },

        // Event Data
        events: { name: 'events', type: 'string' },
        eventsources: { name: 'eventSources', type: 'array' },
        alldaydefault: { name: 'allDayDefault', type: 'boolean' },
        startparam: { name: 'startParam', type: 'string' },
        endparam: { name: 'endParam', type: 'string' },
        timezoneparam: { name: 'timezoneParam', type: 'string' },
        lazyfetching: { name: 'lazyFetching', type: 'boolean' },
        defaulttimedeventduration: { name: 'defaultTimedEventDuration', type: 'duration' },
        defaultalldayeventduration: { name: 'defaultAllDayEventDuration', type: 'duration' },
        forceeventduration: { name: 'forceEventDuration', type: 'boolean' },
        eventdatatransform: { name: 'eventDataTransform', type: 'callback' },
        loading: { name: 'loading', type: 'callback' },

        // Event Rendering
        eventcolor: { name: 'eventColor', type: 'string' },
        eventbackgroundcolor: { name: 'eventBackgroundColor', type: 'string' },
        eventbordercolor: { name: 'eventBorderColor', type: 'string' },
        eventtextcolor: { name: 'eventTextColor', type: 'string' },
        nextdaythreshold: { name: 'nextDayThreshold', type: 'duration' },
        eventrenderwait: { name: 'eventRenderWait', type: 'integer' },
        eventrender: { name: 'eventRender', type: 'callback' },
        eventafterrender: { name: 'eventAfterRender', type: 'callback' },
        eventafterallrender: { name: 'eventAfterAllRender', type: 'callback' },
        eventdestroy: { name: 'eventDestroy', type: 'callback' },

        // Event Dragging & Resizing
        editable: { name: 'editable', type: 'boolean' },
        eventstarteditable: { name: 'eventStartEditable', type: 'boolean' },
        eventdurationeditable: { name: 'eventDurationEditable', type: 'boolean' },
        dragrevertduration: { name: 'dragRevertDuration', type: 'integer' },
        dragopacity: { name: 'dragOpacity', type: 'float' },
        dragscroll: { name: 'dragScroll', type: 'boolean' },
        eventoverlap: { name: 'eventOverlap', type: 'boolean/function' }, 
        eventconstraint: { name: 'eventConstraint', type: 'object' }, 
        eventallow: { name: 'eventAllow', type: 'callback' }, 
        longpressdelay: { name: 'longPressDelay', type: 'integer' },
        eventlongpressdelay: { name: 'eventLongPressDelay', type: 'integer' },
        eventdragstart: { name: 'eventDragStart', type: 'callback' },
        eventdragstop: { name: 'eventDragStop', type: 'callback' },
        eventdrop: { name: 'eventDrop', type: 'callback' },
        eventresizestart: { name: 'eventResizeStart', type: 'callback' },
        eventresizestop: { name: 'eventResizeStop', type: 'callback' },
        eventresize: { name: 'eventResize', type: 'callback' },

        // Dropping External Elements
        droppable: { name: 'droppable', type: 'boolean' },
        dropaccept: { name: 'dropAccept', type: 'function/string' },
        drop: { name: 'drop', type: 'callback' },
        eventreceive: { name: 'eventReceive', type: 'callback' }
    }

    $(function () {
        var calendars = $('.fc');
        for (i = 0; i < calendars.length; i++) {
            var calendarObj = {};
            var data = $(calendars[i]).data();
            for (item in data) {
                var calendarParameter = fullCalendarParameters[item.substring(2).toLowerCase()]
                calendarObj[calendarParameter.name] = parseData(data[item], calendarParameter);
                $(calendars[i]).removeAttr("data-fc-" + item.substring(2));
            }
            //console.log(calendarObj);
            $(calendars[i]).fullCalendar(calendarObj);
        }
    });

    function parseData(data, param) {
        switch (param.type) {
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
                return parseObjectData(data);
            case 'boolean/object':
                return parseBooleanObjectData(data);
            case 'boolean/function':
                return parseBooleanFunctionData(data);
            case 'integer/boolean':
                return (typeof (data) === "number" || typeof (data) == "boolean") ? data : data == "True";
            case 'callback':
                try {
                    return parseFunctionData(JSON.parse(data.replace(/\'/g, '"')).function);
                }
                catch (e) {
                    console.error(e);
                    return null;
                }
            case 'callback/string':
            case 'function/string':
                var value = JSON.parse(data.replace(/\'/g, '"')).function;
                try {
                    return parseFunctionData(value);
                }
                catch (e) {
                    return value;
                }
            case 'custom':
                return parseCustomData(data, param.name);
        }
    }

    function parseObjectData(data) {
        return $.isArray(data) ? data : JSON.parse(data.replace(/\'/g, '"'));
    }

    function parseBooleanObjectData(data) {
        try {
            if (typeof (data) === "boolean") {
                return data;
            }
            else {
                return parseObjectData(data);
            };
        }
        catch (e) {
            console.error(e);
            return null;
        }
    }

    function parseBooleanFunctionData(data) {
        try {
            if (typeof (data) === "boolean") {
                return data;
            }
            else {
                return parseFunctionData(data);
            };
        }
        catch (e) {
            return null;
        }
    }

    function parseFunctionData(data) {
        return eval('(' + data + ')');
    }

    function parseCustomData(data, name) {
        switch (name) {
            case 'customButtons':
                var obj = JSON.parse(data.replace(/\'/g, '"'));
                var objectToReturn = new Object();
                Object.keys(obj).forEach(function (key) {
                    objectToReturn[key] = new Object();
                    Object.keys(obj[key]).forEach(function (childKey) {
                        if (obj[key][childKey] && childKey == 'text')
                            objectToReturn[key][childKey] = obj[key][childKey];
                        else if (obj[key][childKey] && childKey == 'click')
                            objectToReturn[key][childKey] = parseFunctionData(obj[key][childKey]);
                        else if (obj[key][childKey] !== null)
                            objectToReturn[key][childKey] = parseBooleanObjectData(obj[key][childKey]);
                    });
                });
                return objectToReturn;
            case 'height':
            case 'contentHeight':
                if (data === 'auto' || data === 'parent')
                    return data;
                else if (data.match(/px$/))
                    return parseInt(data.slice(0, -2));
                else
                    return parseFunctionData(data);
        }
    }
}(jQuery));