using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.ViewModel.Data
{
    public class AddActivityRequest
    {

        public int ClientDealId { get; set; }
        public int ActivityPointId { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public DateTime? ActivityEndDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string EventId { get; set; }
        public string Email { get; set; }
        public bool GoogleLinked { get; set; }
    }




}

