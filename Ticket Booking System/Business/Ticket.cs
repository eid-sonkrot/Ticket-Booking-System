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
        public bool Compare(Ticket ticket)
        {
            if(!this.seat.Equals(ticket.seat) && ticket.seat!=null)
                return false;
            if (!this.person.Equals(ticket.person) && ticket.person != null)
                return false;
            
            return this.flight.Compare(ticket.flight);
        }
    }
}