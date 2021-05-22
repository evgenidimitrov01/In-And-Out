using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut_2.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        public int Amount { get; set; }
        [DisplayName("Expense type")]
        public int ExpTypeId { get; set; }
        [ForeignKey("ExpTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
