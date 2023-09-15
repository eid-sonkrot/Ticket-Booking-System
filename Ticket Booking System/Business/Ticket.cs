using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Business
{
    public class Ticket
    {  
        public Person Person { get; set; }
        [Required]
        public Flight Flight { get; set; }
        public Seat Seat { get; set; }
     
        
        public Ticket(Person person, Flight flight, Seat seat)
        {
            this.Person = person;
            this.Flight = flight;
            this.Seat = seat;
        }
        public Ticket()
        {     
        }
        public bool Compare(Ticket ticket)
        {
            if(!this.Seat.Equals(ticket.Seat) && ticket.Seat!=null)
                return false;
            if (!this.Person.Equals(ticket.Person) && ticket.Person != null)
                return false;
            return this.Flight.Compare(ticket.Flight);
        }
        public Ticket FillFromStrings(string[] values)
        {
            if (values.Length != 22)
            {
                throw new ArgumentException("Exactly 22 values are required to fill the Ticket record.");
            }
            return new Ticket
            {
                Person = new Person().FillFromStrings(values.Take(3).ToArray()),
                Flight = new Flight().FillFromStrings(values.Skip(3).Take(18).ToArray()),
                Seat = new Seat().FillFromStrings(new string[] { values[21] })
            };
        }
        public string[] ToArrayOfString()
        {
            return Person.ToArrayOfString().
                Concat(Flight.ToArrayOfString().
                Concat(Seat.ToArrayOfString())).
                ToArray();
        }
    }
}