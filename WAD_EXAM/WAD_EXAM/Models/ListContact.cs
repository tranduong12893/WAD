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
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public String Address { get; set; }

    }
}