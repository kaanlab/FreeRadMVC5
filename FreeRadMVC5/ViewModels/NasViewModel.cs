using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.ViewModels
{
    public class NasViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 3)]
        [Display(Name = "Сетевое устройство")]
        public string NasName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Короткое имя")]
        public string ShortName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Range(0, 65400)]
        [Display(Name = "Порты")]
        public int? Ports { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Секрет")]
        public string Secret { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Community { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}