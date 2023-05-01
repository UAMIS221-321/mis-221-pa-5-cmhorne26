namespace mis_221_pa_5_cmhorne26
{
    public class managereports
    {
        
    public string IndividualCustomerSessions(List<Booking> bookings, string customerEmail)
    {
        var customerSessions = bookings.Where(b => b.CustomerEmail == customerEmail).OrderBy(b => b.TrainingDate);
        var report = $"Individual Customer Sessions for {customerEmail}\n\n";
        foreach (var session in customerSessions)
        {
            report += $"{session.TrainingDate} - {session.TrainerName} - {session.Status}\n";
        }
        return report;
    }

    public string HistoricalCustomerSessions(List<Booking> bookings)
    {
        var sessionsByCustomer = bookings.GroupBy(b => b.CustomerEmail).OrderBy(g => g.Key);
        var report = "Historical Customer Sessions\n\n";
        foreach (var group in sessionsByCustomer)
        {
            report += $"Customer: {group.Key}\n";
            report += $"Total Sessions: {group.Count()}\n";
            report += "Sessions:\n";
            foreach (var session in group.OrderBy(s => s.TrainingDate))
            {
                report += $"{session.TrainingDate} - {session.TrainerName} - {session.Status}\n";
            }
            report += "\n";
        }
        return report;
    }

    public string HistoricalRevenueReport(List<Listing> listings, List<Booking> bookings)
    {
        var revenueByMonthYear = bookings
            .Where(b => b.Status == "completed")
            .GroupBy(b => new { b.TrainingDate.Year, b.TrainingDate.Month })
            .OrderBy(g => g.Key.Year)
            .ThenBy(g => g.Key.Month);

        var report = "Historical Revenue Report\n\n";
        foreach (var group in revenueByMonthYear)
        {
            decimal monthlyRevenue = 0;
            foreach (var booking in group)
            {
                var listing = listings.FirstOrDefault(l => l.ListingID == booking.SessionID);
                if (listing != null)
                {
                    monthlyRevenue += listing.SessionCost;
                }
            }
            report += $"Year: {group.Key.Year}, Month: {group.Key.Month}, Revenue: ${monthlyRevenue}\n";
        }
        return report;
    }

    public void SaveReportToFile(string report, string fileName)
    {
        File.WriteAllText(fileName, report);
    }
    }
}