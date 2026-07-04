using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string idUserGroup { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}