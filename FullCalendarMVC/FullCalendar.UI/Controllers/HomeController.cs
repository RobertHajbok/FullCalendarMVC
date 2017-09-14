using FullCalendar.UI.Extensions;
using FullCalendar.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FullCalendar.UI.Controllers
{
    public class HomeController : Controller
    {
        Random rnd = new Random();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDiaryEvents(DateTime start, DateTime end)
        {
            return Json(LoadAllAppointmentsInDateRange(start, end).Select(x => new
            {
                id = x.ID,
                title = x.Title,
                start = x.StartDateString,
                end = x.EndDateString,
                color = x.StatusColor,
                className = x.ClassName,
                someKey = x.SomeImportantKeyID,
                allDay = false
            }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public IEnumerable<DiaryEvent> LoadAllAppointmentsInDateRange(DateTime fromDate, DateTime toDate)
        {
            List<DiaryEvent> result = new List<DiaryEvent>();
            foreach (var item in GetAppointmentDiaries().Where(s => s.DateTimeScheduled >= fromDate && s.DateTimeScheduled.AddMinutes(s.AppointmentLength) <= toDate))
            {
                DiaryEvent rec = new DiaryEvent
                {
                    ID = item.ID,
                    SomeImportantKeyID = item.SomeImportantKey,
                    StartDateString = item.DateTimeScheduled.ToString("s"), // "s" is a preset format that outputs as: "2009-02-27T12:12:22"
                    EndDateString = item.DateTimeScheduled.AddMinutes(item.AppointmentLength).ToString("s"), // field AppointmentLength is in minutes
                    Title = item.Title + " - " + item.AppointmentLength.ToString() + " mins",
                    StatusString = Enums.GetName((AppointmentStatus)item.StatusENUM)
                };
                rec.StatusColor = Enums.GetEnumDescription<AppointmentStatus>(rec.StatusString);
                string ColorCode = rec.StatusColor.Substring(0, rec.StatusColor.IndexOf(":"));
                rec.ClassName = rec.StatusColor.Substring(rec.StatusColor.IndexOf(":") + 1, rec.StatusColor.Length - ColorCode.Length - 1);
                rec.StatusColor = ColorCode;
                result.Add(rec);
            }
            return result;
        }

        [NonAction]
        public IEnumerable<AppointmentDiary> GetAppointmentDiaries()
        {
            List<AppointmentDiary> appointmentDiaries = new List<AppointmentDiary>();
            for (int i = 0; i < 30; i++)
            {
                AppointmentDiary item = new AppointmentDiary
                {
                    ID = i,
                    Title = "Appt: " + i.ToString(),
                    SomeImportantKey = i,
                    StatusENUM = rnd.Next(0, 3) // random is exclusive - we have three status enums
                };
                item.DateTimeScheduled = i <= 5 ? GetRandomAppointmentTime(false, true) : item.DateTimeScheduled = GetRandomAppointmentTime(i % 2 == 0, false);
                item.AppointmentLength = rnd.Next(1, 5) * 15; // appoiment length in blocks of fifteen minutes in this demo
                appointmentDiaries.Add(item);
            }

            return appointmentDiaries;
        }

        /// <summary>
        /// sends back a date/time +/- 15 days from todays date
        /// </summary>
        [NonAction]
        public DateTime GetRandomAppointmentTime(bool GoBackwards, bool Today)
        {
            var baseDate = DateTime.Today;
            if (Today)
                return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, rnd.Next(9, 18), rnd.Next(1, 6) * 5, 0);

            int rndDays = rnd.Next(1, 16);
            return new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, rnd.Next(9, 18), rnd.Next(1, 6) * 5, 0).AddDays(GoBackwards ? rndDays * -1 : rndDays);
        }
    }
}