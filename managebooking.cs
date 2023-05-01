namespace mis_221_pa_5_cmhorne26
{
    public class BookingManager
    {
        private const string FileName = "transactions.txt";
    private List<Booking> bookings;

    public BookingManager()
    {
        bookings = LoadBookings();
    }

    public List<Booking> LoadBookings()
    {
        if (!File.Exists(FileName))
        {
            return new List<Booking>();
        }

        var lines = File.ReadAllLines(FileName);
        return lines.Select(line =>
        {
            var parts = line.Split("#");
            return new Booking(int.Parse(parts[0].Trim()), parts[1].Trim(), parts[2].Trim(), DateTime.Parse(parts[3].Trim()), int.Parse(parts[4].Trim()), parts[5].Trim(), parts[6].Trim());
        }).ToList();
    }

    public void SaveBookings()
    {
        var lines = bookings.Select(booking => booking.ToString()).ToArray();
        File.WriteAllLines(FileName, lines);
    }

    public List<Listing> GetAvailableSessions(List<Listing> listings)
    {
        return listings.Where(listing => !listing.ListingTaken).ToList();
    }

    public void BookSession(Listing listing, int sessionID, string customerName, string customerEmail)
    {
        listing.ListingTaken = true;
        Booking newBooking = new Booking(sessionID, customerName, customerEmail, listing.SessionDate, listing.ListingID, listing.TrainerName, "booked");
        bookings.Add(newBooking);
        SaveBookings();
    }

    public void UpdateBookingStatus(int sessionID, string status)
    {
        var index = bookings.FindIndex(booking => booking.SessionID == sessionID);
        if (index != -1)
        {
            bookings[index].Status = status;
            SaveBookings();
        }
    }
    }
}