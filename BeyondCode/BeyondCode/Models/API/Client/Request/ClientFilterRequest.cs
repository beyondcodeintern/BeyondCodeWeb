using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.ViewModel.Data
{
    public class DepartmentRequest
    {
      
        public string Code { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}