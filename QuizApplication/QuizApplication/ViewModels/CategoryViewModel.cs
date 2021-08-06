using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace QuizApplication.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name ="Category")]
        [Required(ErrorMessage ="Categoryid Required")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Display(Name ="Queistion")]
        [Required(ErrorMessage ="Question is Required")]
        public string QueistionNam { get; set; }
        public string OptionName { get; set; }
        public IEnumerable<SelectListItem> ListofCategory { get; set; }
    }
}