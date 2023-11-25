using FlowPanelApp.Context;

namespace FlowPanelApp.Services.CalendarService
{
    public class CalendarService : ICalendarService
    {
        private readonly FlowContext _flowContext;
        public CalendarService(FlowContext flowContext)
        {
            _flowContext = flowContext;
        }
    }
}
