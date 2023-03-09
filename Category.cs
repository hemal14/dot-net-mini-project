using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       // [Range( 1, 100, ErrorMessage ="Display Order must be between 1 and 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


    }
}
