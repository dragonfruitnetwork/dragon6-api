using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core
{
    public class Regions
    {
        public enum Region
        {
            EMEA,
            NCSA,
            APAC
        };
    }
    public class AccountStatus
    {
        public bool IsVerifed { get; set; }
        public bool IsBlocked { get; set; }
        public string GUID { get; set; }
        public string YTLink { get; set; }
        public string TwitchLink { get; set; }

        public static List<AccountStatus> UsersList = new List<AccountStatus>();

        public static AccountStatus GetStatus(string guid)
        {
            return UsersList.Where(x => x.GUID == guid).DefaultIfEmpty(new AccountStatus
            {
                IsVerifed = false,
                IsBlocked = false
            }).First();
        }
    }
}
