using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class EventSourcesPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventSources));
            FullCalendarParameters parameters = new FullCalendarParameters();
            EventSourcesPropertyParser parser = new EventSourcesPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ListIsEmpty_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventSources));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventSources = new List<EventSource>()
            };
            EventSourcesPropertyParser parser = new EventSourcesPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ListIsNotEmpty_ValuesIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventSources));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventSources = new List<EventSource>
                {
                    new EventSource
                    {
                        Id = 1,
                        BackgroundColor = Color.DarkGray,
                        BorderColor = Color.Blue,
                        TextColor = Color.Gold,
                        ClassName = "test",
                        Rendering = Rendering.Background,
                        Constraint = new EventConstraint(new BusinessHour
                        {
                            Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                            Start = TimeSpan.FromHours(10),
                            End = TimeSpan.FromHours(15)
                        }),
                        AllDayDefault = true,
                        Url = "/Home/GetDiaryEvents"
                    },
                    new EventSource
                    {
                        Id = 2,
                        Events = Events.AsArray(new List<Event>
                        {
                            new Event
                            {
                                Id = 1,
                                Title = "Title",
                                AllDay = false,
                                ClassName = "test-class",
                                Constraint = new EventConstraint(new BusinessHour
                                {
                                    Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                                    Start = TimeSpan.FromHours(10),
                                    End = TimeSpan.FromHours(15)
                                }),
                                Color = Color.DarkRed,
                                AdditionalFields = new Dictionary<string, string>
                                {
                                    { "description", "this is the description" },
                                    { "other", "this is another additional field" }
                                }
                            }
                        }),
                        Type = "POST",
                        Error = "function() { }",
                        Data = new Dictionary<string, string>
                        {
                            { "custom_param1", "something" },
                            { "custom_param2", "somethingelse" }
                        }
                    }
                }
            };
            EventSourcesPropertyParser parser = new EventSourcesPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-EventSources", @"[{'id':1,'events':null,'color':null,'backgroundColor':'#A9A9A9','borderColor':'#0000FF','textColor':'#FFD700','className':'test','editable':false,'startEditable':true,'durationEditable':true,'rendering':'background','overlap':true,'constraint':{'dow':[4,5],'start':'10:00','end':'15:00'},'allDayDefault':true,'eventDataTransform':null,'url':'/Home/GetDiaryEvents','startParam':null,'endParam':null,'timezoneParam':null,'type':null,'success':null,'error':null,'cache':false,'data':null},{'id':2,'events':[{'id':1,'title':'Title','allDay':false,'start':null,'end':null,'url':null,'className':'test-class','editable':false,'startEditable':true,'durationEditable':true,'rendering':null,'overlap':true,'constraint':{'dow':[4,5],'start':'10:00','end':'15:00'},'color':'#8B0000','backgroundColor':null,'borderColor':null,'textColor':null,'googleCalendarId':null,'additionalFields':{'description':'this is the description','other':'this is another additional field'}}],'color':null,'backgroundColor':null,'borderColor':null,'textColor':null,'className':null,'editable':false,'startEditable':true,'durationEditable':true,'rendering':null,'overlap':true,'constraint':null,'allDayDefault':null,'eventDataTransform':null,'url':null,'startParam':null,'endParam':null,'timezoneParam':null,'type':'POST','success':null,'error':'function() { }','cache':false,'data':{'custom_param1':'something','custom_param2':'somethingelse'}}]");
        }
    }
}