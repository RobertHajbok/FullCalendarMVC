using System.ComponentModel;

namespace FullCalendar.UI.Models
{
    // resource: html-color-codes  http://html-color-codes.info/
    // left part stores color, right part stores className for html rendering
    public enum AppointmentStatus
    {
        [Description("#01DF3A:ENQUIRY")] // green
        Enquiry = 0,
        [Description("#FF8000:BOOKED")] // orange
        Booked,
        [Description("#FF0000:CONFIRMED")] // red
        Confirmed

    }
}