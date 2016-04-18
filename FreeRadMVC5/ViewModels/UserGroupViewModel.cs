using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.ViewModels
{
    public class UserGroupViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Пользователь")]
        public string UserName { get; set; }

        [Display(Name = "Группа")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "Приоритет")]
        [Range(1, 100)]
        public int Priority { get; set; }
    }
}