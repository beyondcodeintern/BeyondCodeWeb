using BeyondCode.Models.API;
using BeyondCode.Models.API.Agent;
using BeyondCode.Models.API.Report;
using BeyondCode.Models.Data;
using BeyondCode.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondCode.Models.ViewModel
{
    public class ReferralListViewModel
    {
        public ReferralListViewModel()
        {
            Status = new List<MasterData>();
            ReferralData = new ReferralData();
            Users = new List<AgentUser>();

        }
        public List<MasterData> Status { get; set; }
        public ReferralData ReferralData { get; set; }
        public List<AgentUser> Users { get; set; }

    }
    public class ReferralData
    {
        public ReferralData()
        {
            Referral = new List<Referral>();
            Paging = new Paging { PageSize = 10, CurrentPage = 1 };
        }
        public List<Referral> Referral { get; set; }
        public Paging Paging { get; set; }
    }
}