using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASender
{
    public class AutoResponderLogs
    {
        string number;
        string dateContacted;
        int ruleID;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
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

        public string DateContacted
        {
            get
            {
                return dateContacted;
            }
            set
            {
                dateContacted = value;
            }
        }
        public AutoResponderLogs(string number,int ruleID,string dateContacted)
        {
            this.number = number;
            this.ruleID = ruleID;
            this.dateContacted = dateContacted;
        }
    }
}
