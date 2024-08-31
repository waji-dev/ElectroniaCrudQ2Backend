using System.ComponentModel.DataAnnotations;
namespace ElectroniaCrudQ2Backend.Models.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}