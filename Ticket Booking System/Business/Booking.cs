using System;

namespace TicketBookingSystem.Business
{
    public class Booking
    {
        private List<Ticket> tickets=new List<Ticket>();
        private BookingId bookingId { get; set; }
        private Date bookingDate { get; set; }
        private BookingStatus bookingStatus { get; set; }
        private Country departureCountry { get; set; }
        private Country destinationCountry { get; set; }
        private Date? departureDate { get; set; }
        private Date? arrivalDate { get; set; }
        private JourneyStatus journeyStatus { get; set; }
        private Price price { get; set; }

        public Booking(List<Ticket> tickets, BookingStatus bookingStatus,Date bookingDate)
        {
            this.tickets = tickets;
            this.bookingId = GenerateId();
            this.bookingDate = bookingDate;
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
            var prices = this.tickets.Select(ticket => ticket.price).ToList();
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
    }
}