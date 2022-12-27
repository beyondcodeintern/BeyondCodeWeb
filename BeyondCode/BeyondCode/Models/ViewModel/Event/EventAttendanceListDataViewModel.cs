using BeyondCode.Models.API.Event.Response;
using BeyondCode.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.ViewModel
{
    public class EventAttendanceListDataViewModel
    {
        public EventAttendanceListDataViewModel()
        {
            EventAttendanceList = new List<EventAttendanceListResponse>();
            Paging = new Paging { PageSize = 10, CurrentPage = 1 };
        }
        public List<EventAttendanceListResponse> EventAttendanceList { get; set; }
        public Paging Paging { get; set; }

        public int? EventId { get; set; }

        public int? EventDateId { get; set; }
    }
}