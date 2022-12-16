using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaliphWeb.Models.API.Agent;
using CaliphWeb.Models.API.Resource;
using CaliphWeb.Models.Data;
using CaliphWeb.ViewModel;


namespace CaliphWeb.Models.ViewModel
{
    public class ResourceListViewModel
    {

        public ResourceListViewModel()
        {
            Users = new List<AgentUser>();
            Status = new List<MasterData>();
        }


        public List<MasterData> Status { get; set; }
        public List<AgentUser> Users { get; set; }


    }
}