using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WAD_EXAM.Models
{
    public class ListContact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter ContactNumber")]
        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "Enter ContactName")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Enter GroupName")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "Enter HireDate")]
        public string HireDate { get; set; }
        [Required(ErrorMessage = "Enter BirthDay")]
        public string BirthDay { get; set; }

    }
}