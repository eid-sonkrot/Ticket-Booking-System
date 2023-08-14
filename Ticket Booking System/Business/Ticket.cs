using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Ticket
    {  
        public Person person { get; set; }
        [Required]
        public Flight flight { get; set; }
        public Seat seat { get; set; }
     
        
        public Ticket(Person person, Flight flight, Seat seat)
        {
            this.person = person;
            this.flight = flight;
            this.seat = seat;
        }
        public Ticket()
        {
        }
    }
}