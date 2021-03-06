using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcertApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category code is a required field")]
        public string CategoryCode { get; set; }
        [Required(ErrorMessage = "Category Status is a required field")]
        public bool IsActive { get; set; }
    }
}
