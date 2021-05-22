using System.ComponentModel.DataAnnotations;

namespace InAndOut_2.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
