using System.ComponentModel.DataAnnotations;

namespace wda2.Models
{
    public class Position
    {
        public int Id { get; set; }

        [MaxLength(20,ErrorMessage = "maximum 20 characters")]
        public string PositionName { get; set; }
        public float SalaryPerHour { get; set; }

        public List<Employee> Employee { get; set; }
    }
}
