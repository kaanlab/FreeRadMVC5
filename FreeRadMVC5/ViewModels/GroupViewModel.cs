using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Группа")]
        public string GroupName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Атрибут")]
        public string Attribute { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1)]
        [Display(Name = "Оператор")]
        public string Op { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}