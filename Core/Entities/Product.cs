using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
   public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product code is a required field")]
        public string ProductCode { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Category Name is a required field")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Price is a required field")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string UserEmail { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
