using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeyondCode.Models.API.Agent;
using BeyondCode.Models.API.Resource;
using BeyondCode.Models.Data;
using BeyondCode.ViewModel;


namespace BeyondCode.Models.ViewModel
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