using CaliphWeb.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliphWeb.ViewModel
{
    public class Resource
    {
        public string Name { get; set; }

        public string Url { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}