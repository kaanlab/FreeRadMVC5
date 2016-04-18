using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    public class Nas
    {
        public int Id { get; set; }
        public string NasName { get; set; }
        public string ShortName { get; set; }
        public string Type { get; set; }
        public int? Ports { get; set; }
        public string Secret { get; set; }
        public string Community { get; set; }
        public string Description { get; set; }
    }
}