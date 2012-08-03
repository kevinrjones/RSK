using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SignalR.Hubs;

namespace TheatreBooking.Hubs
{
    public class TheatreBookingHub : Hub
    {
        private ITestService _service;
        private static readonly Theatre Theatre = new Theatre();

        public TheatreBookingHub(ITestService service)
        {
            _service = service;
        }

        public Task<Theatre> GetInitialData()
        {
            return Task.Factory.StartNew(() =>
            {
                // Don't do this in the real world
                Thread.Sleep(500);
                return Theatre;
            });
        }

        public void BookSeat(string row, int seatNumber, bool booked)
        {
            Theatre.UpdateSeat(row, seatNumber, booked);
            Clients.updateTheatre(Theatre);
        }
    }

    public class Seat
    {
        public char row { get; set; }
        public int seatNumber { get; set; }
        public bool booked { get; set; }
    }

    public class Row
    {
        private const int SeatsPerRow = 10;

        public Row(int row)
        {
            seats = new Seat[SeatsPerRow];
            for (int i = 0; i < seats.Length; i++)
            {
                seats[i] = new Seat{row = Convert.ToChar(row), seatNumber = i, booked = false};
            }
        }
        public Seat[] seats { get; set; }

        public void UpdateSeat(int seatNumber, bool booked)
        {
            seats[seatNumber].booked = booked;
        }
    }

    public class Theatre
    {
        private const int Rows = 5;

        public Theatre()
        {
            rows = new Row[Rows];
            for (int i = 0; i < Rows; i++)
            {
                rows[i] = new Row(i);
            }
        }
        public Row[] rows { get; set; }

        public void UpdateSeat(string row, int seatNumber, bool booked)
        {
            int rowNumber = Convert.ToInt32(row[0]);
            rows[rowNumber].UpdateSeat(seatNumber, booked);
        }
    }
}