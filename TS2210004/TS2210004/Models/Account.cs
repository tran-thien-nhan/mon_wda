using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TS2210004.Models
{
    public class Account
    {
        [Key]
        [RegularExpression(@"^A[0-9][0-9]?|100$", ErrorMessage = "Không đúng định dạng Axxx, với xxx là số từ 0 đến 100")]
        [Required(ErrorMessage = "bắt buộc")]
        public string AccountNo { get; set; }
        [MaxLength(50, ErrorMessage = "maximum 50 characters")]
        [Required(ErrorMessage = "bắt buộc")]
        public string AccountName { get; set; }
        [MaxLength(20, ErrorMessage = "maximum 20 characters")]
        [Required(ErrorMessage = "bắt buộc")]
        public string PinCode { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        [Precision(15)]
        [Required(ErrorMessage = "bắt buộc")]
        public decimal Balance { get; set; }
        public bool Role { get; set; }
    }
}
