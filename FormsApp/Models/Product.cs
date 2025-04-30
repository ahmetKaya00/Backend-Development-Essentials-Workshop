using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models{

    public class Product{

        [Display(Name ="Ürün Id")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name ="Ürün Adı")]
        [StringLength(100)]
        public string? Name {get;set;} = string.Empty; 
        
        [Required(ErrorMessage = "Ürün Fiyatı boş bırakılamaz!")]
        [Display(Name ="Ürün Fiyatı")]
        [Range(0,150000)]
        public decimal? Price {get;set;}
        
        [Display(Name ="Ürün Görseli")]
        public string Image {get;set;} = string.Empty;
        public bool isActive {get;set;}
        public int CategoryId {get;set;}

    }
}