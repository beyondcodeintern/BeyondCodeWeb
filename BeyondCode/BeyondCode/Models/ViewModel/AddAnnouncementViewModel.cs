using BeyondCode.Models.API.Agent;
using BeyondCode.ViewModel;
using System.Collections.Generic;

namespace BeyondCode.Models.ViewModel
{
    public class AddAnnouncementViewModel
    {
        public List<MasterData> AnnouncementTypeList { get; set; }
        public List<AgentUser> AgentUsers { get; set; }
    }
}