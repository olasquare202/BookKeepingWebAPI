using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookKeepingWeb.Models
{
    public class Category
    {
        [Key]//make d Id primary key
        public int Id { get; set; }
        [Required]//Name is compulsory
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
