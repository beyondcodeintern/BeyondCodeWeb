using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.API.Budget
{
    public class BudgetGroupDeleteRequest
    {
        public int BudgetGroupId { get; set; }
        public string UpdatedBy { get; set; }
    }


    public class BudgetMonthlyDeleteRequest
    {
        public int BudgetMonthlyId { get; set; }
        public string UpdatedBy { get; set; }
    }
}