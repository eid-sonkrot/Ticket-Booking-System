using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TicketBookingSystem.Business
{
    public class Booking
    {
        public List<Ticket> Tickets { get; set; }=new List<Ticket>(){ };
        public ID BookingId { get; set; }
        public Date BookingDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public Country DepartureCountry { get; set; }
        public Country DestinationCountry { get; set; }
        public Date? DepartureDate { get; set; }
        public Date? ArrivalDate { get; set; }
        public JourneyStatus JourneyStatus { get; set; }
        public Price Price { get; set; }

        public Booking(List<Ticket> tickets, BookingStatus bookingStatus)
        {
            this.Tickets = tickets;
            this.BookingId = GenerateId();
            this.BookingDate = new Date { Day = DateTime.Now.Day, Year = DateTime.Now.Year, Month = DateTime.Now.Month };
            this.BookingStatus = bookingStatus;
            this.DepartureCountry = tickets.First().Flight.DepartureCountry;
            this.DestinationCountry = tickets.Last().Flight.DestinationCountry;
            this.DepartureDate = tickets.First().Flight.DepartureDate;
            this.ArrivalDate = tickets.Last().Flight.ArrivalDate;
            this.JourneyStatus = SetjourneyStatus();
            this.Price = ClaculatePrice();
        }
        public Booking()
        {

        }
        private Price ClaculatePrice()
        {
            var prices = this.Tickets.Select(ticket => ticket.Flight.Price).ToList();

            return new Price
            {
                price = prices.Sum(p => p.price),
                Currency = prices.FirstOrDefault().Currency
            };
        }
        private ID GenerateId()
        {
            var bookingId = new ID();
            var id = (string)null;
            var maxValue = int.MaxValue - 1;
            var random = new Random();

            id = string.Concat(Enumerable.Range(0, 8).Select(_ =>
            (random.Next(1, maxValue) % random.Next(1, maxValue)).ToString().FirstOrDefault()));
            bookingId.Id = id;
            return bookingId;
        }
        private JourneyStatus SetjourneyStatus()
        {
            var isMulticity = Tickets.First().Flight.DepartureCountry == Tickets.Last().Flight.DestinationCountry;

            if (Tickets.Count() == 1)
                return JourneyStatus.OneWay;
            if (Tickets.Count() == 2 & isMulticity)
                return JourneyStatus.MultiCity;
            return JourneyStatus.RoundTrip;
        }
        public bool Compare(Booking booking)
        {
            var isValid = this.Tickets.Where(ticket =>
            booking.Tickets.All(ticket2 =>
            ticket.Compare(ticket2))).Count().Equals(Tickets.Count());

            if (!isValid)
                return false;
            if (!booking.JourneyStatus.Equals(this.JourneyStatus) && booking.JourneyStatus != null)
                return false;
            if (!this.Price.Equals(booking.Price))
                return false;
            if (!this.BookingDate.Equals(booking.BookingDate) && booking.BookingDate != null)
                return false;
            if (!this.DepartureDate.Equals(booking.DepartureDate) && booking.DepartureDate != null)
                return false;
            if (!this.ArrivalDate.Equals(booking.ArrivalDate) && booking.ArrivalDate != null)
                return false;
            if (this.BookingId.Equals(booking.BookingId) && booking.BookingId != null)
                return false;
            return true;
        }
        public Booking FillFromStrings(string[] values)
        {
            var tickets = new List<Ticket>();

            for (var i = 0; i < values.Length - 1; i += 21)
            {
                tickets.Add(new Ticket().FillFromStrings(values.Skip(i).Take(21).ToArray()));
            }
            return new Booking(tickets, Enum.Parse<BookingStatus>(values[values.Length - 1])); 
        }
        public string[] ToArrayOfString()
        {
            return Tickets.SelectMany(ticket => ticket.ToArrayOfString()).Concat(BookingId.ToArrayOfString())
            .Concat(BookingDate.ToArrayOfString())
            .Concat(new string[] { BookingStatus.ToString() })
            .Concat(DepartureCountry.ToArrayOfString())
            .Concat(DestinationCountry.ToArrayOfString())
            .Concat(DepartureDate.ToArrayOfString())
            .Concat(ArrivalDate.ToArrayOfString())
            .Concat(new string[] { JourneyStatus.ToString() })
            .Concat(Price.ToArrayOfString()) 
            .ToArray();
        }
    }
}