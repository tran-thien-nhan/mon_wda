using System.ComponentModel.DataAnnotations;

namespace wda4.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "maximum 30 characters")]
        public string Username { get; set; }
        public int RoomType {  get; set; }
        public DateTime BeginDay { get; set; }
        public int DayStay { get; set; }
    }
}
