using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Ticket
    {  
        public Person person { get; set; }
        [Required]
        public Flight flight { get; set; }
        public Seat seat { get; set; }
        [Required]
        BookingId bookingId { get; set; }
        [Required]
        public Class Class { get; set; }

        public Ticket(Person person, Flight flight, Seat seat, BookingId bookingId, Class @class)
        {
            this.person = person;
            this.flight = flight;
            this.seat = seat;
            this.bookingId = bookingId;
            Class = @class;
        }
        public Ticket()
        {
        }
    }
}