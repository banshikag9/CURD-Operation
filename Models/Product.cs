using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        [Key]   //for primary key
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]  //for compulsory
        [Display(Name ="Name of Product")]
        public string? ProductName { get; set; }
        

        [Required(ErrorMessage = "Please Enter Product Description")]
        [Display(Name = "Description of Product")]

        public string? ProductDescription { get; set; }
        
        [Required(ErrorMessage = "Please Enter Product Price")]
        [Display(Name = "Price of Product")]





        public double Price { get; set; }
        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public int Quantity { get; set; }



    }
}
