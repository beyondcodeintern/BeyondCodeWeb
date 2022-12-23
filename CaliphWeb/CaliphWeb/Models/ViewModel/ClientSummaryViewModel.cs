using BeyondCode.Models.API.Agent;
using BeyondCode.Models.API.Report;
using BeyondCode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.ViewModel
{
    public class ClientSummaryViewModel
    {
        public List<AgentUser> Users { get; set; }

        public List<ClientSummary>  ClientSummaries { get; set; }
    }
}