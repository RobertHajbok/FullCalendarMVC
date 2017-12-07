using System.Web.Script.Serialization;

namespace FullCalendar.Tests.Mocks
{
    public class ScriptIgnoreAttributeMock
    {
        [ScriptIgnore]
        public int Id { get; set; }
    }
}
