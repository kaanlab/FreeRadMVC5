using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int Priority { get; set; }
    }
}