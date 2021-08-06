using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizApplication.ViewModels
{
    public class AdminViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string UserName { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}