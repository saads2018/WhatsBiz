using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaAutoReplyBot.Models;

namespace WASender.Model
{
    public class RulePause
    {
        int ruleID, daysCount;
        public RulePause(int ruleID,int daysCount)
        {
            this.ruleID = ruleID;
            this.daysCount = daysCount;
        }

        public int RuleID
        {
            get
            {
                return ruleID;
            }
            set
            {
                ruleID = value;
            }
        }
        public int DaysCount
        {
            get
            {
                return daysCount;
            }
            set
            {
                daysCount = value;
            }
        }

    }
}
