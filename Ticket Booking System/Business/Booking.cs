using System;

namespace TicketBookingSystem.Business
{
    public class Booking
    {
        public List<Ticket> tickets=new List<Ticket>();
        public BookingId bookingId { get; set; }
        public Date bookingDate { get; set; }
        public BookingStatus bookingStatus { get; set; }
        public Country departureCountry { get; set; }
        public Country destinationCountry { get; set; }
        public Date? departureDate { get; set; }
        public Date? arrivalDate { get; set; }
        public JourneyStatus journeyStatus { get; set; }
        public Price price { get; set; }

        public Booking(List<Ticket> tickets, BookingStatus bookingStatus)
        {
            this.tickets = tickets;
            this.bookingId = GenerateId();
            this.bookingDate = new Date { Day=DateTime.Now.Day,Year=DateTime.Now.Year,Month=DateTime.Now.Month};
            this.bookingStatus = bookingStatus;
            this.departureCountry = tickets.First().flight.departureCountry;
            this.destinationCountry = tickets.Last().flight.destinationCountry;
            this.departureDate =tickets.First().flight.departureDate;
            this.arrivalDate = tickets.Last().flight.arrivalDate;
            this.journeyStatus= SetjourneyStatus();
            this.price = ClaculatePrice();
        }
        private Price ClaculatePrice()
        {
            var prices = this.tickets.Select(ticket => ticket.flight.price).ToList();
            return new Price
            {
                price = prices.Sum(p => p.price),
                currency = prices.FirstOrDefault().currency
            };
        }
        private BookingId GenerateId()
        {
            var bookingId = new BookingId();
            var id = (string)null;
            var maxValue=int.MaxValue-1;
            var random=new Random();

            id= string.Concat(Enumerable.Range(0, 8).Select(_ =>
            (random.Next(1, maxValue) % random.Next(1, maxValue)).ToString().FirstOrDefault()));
            bookingId.Id = id;
            return bookingId;
        }
        private JourneyStatus SetjourneyStatus()
        {
            var isMulticity = tickets.First().flight.departureCountry == tickets.Last().flight.destinationCountry;

            if (tickets.Count() == 1)
                return JourneyStatus.OneWay;
            if(tickets.Count() == 2 & isMulticity )
                return JourneyStatus.MultiCity;
            return JourneyStatus.RoundTrip;
        }
        public bool Compare(Booking booking)
        {
            var isValid = tickets.Count(ticket => booking.tickets.All(ticket2=>
                ticket.Compare(ticket2))).Equals(tickets.Count());
                                            
            if (!isValid)
                return false;
            if (booking.journeyStatus != null &&!booking.journeyStatus.Equals( this.journeyStatus ) )
                return false;
            if (booking.price != null && !this.price.Equals(booking.price))
                return false;
            if (booking.bookingDate!=null&&!this.bookingDate.Equals(booking.bookingDate)) 
                return false;
            if (booking.departureDate != null&&!this.departureDate.Equals(booking.departureDate))
                return false;
            if (booking.arrivalDate != null && !this.arrivalDate.Equals(booking.arrivalDate))
                return false;
            if (booking.bookingId != null && this.bookingId.Equals(booking.bookingId) )
                return false;
            return true;
        }
    }
}