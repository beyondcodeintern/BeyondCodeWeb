using CaliphWeb.Models;
using System.Collections.Generic;

namespace CaliphWeb.Services
{

    public class BonusService
    {
        public BonusService()
        {

        }


        public static List<BonusContest> GetContests()
        {
            if (BonusContests == null)
            {
                BonusContests = new List<BonusContest>();
                BonusContests.Add(new BonusContest { ACE = 40000, PR_D0 = 90, Cases = 12, BonusPercent = 0.04 });
                BonusContests.Add(new BonusContest { ACE = 60000, PR_D0 = 90, Cases = 12, BonusPercent = 0.06 });
                BonusContests.Add(new BonusContest { ACE = 90000, PR_D0 = 90, Cases = 12, BonusPercent =0.08 });
                BonusContests.Add(new BonusContest { ACE = 120000, PR_D0 = 90, Cases = 14, BonusPercent =0.09 });
                BonusContests.Add(new BonusContest { ACE = 240000, PR_D0 = 90, Cases = 14, BonusPercent =0.11 });
                BonusContests.Add(new BonusContest { ACE = 360000, PR_D0 = 90, Cases = 14, BonusPercent =0.13 });
                return BonusContests;
            }
            else
                return BonusContests;
        }
        private static List<BonusContest>  BonusContests { get; set; }
    }


}