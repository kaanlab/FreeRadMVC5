using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Attribute { get; set; }
        public string Op { get; set; }
        public string Value { get; set; }
    }
}