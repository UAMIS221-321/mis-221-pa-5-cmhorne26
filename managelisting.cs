namespace mis_221_pa_5_cmhorne26
{
    public class ListingManager
    {
        private const string FileName = "listings.txt";
    private List<Listing> listings;

    public ListingManager()
    {
        listings = LoadListings();
    }

    public List<Listing> LoadListings()
    {
        if (!File.Exists(FileName))
        {
            return new List<Listing>();
        }

        var lines = File.ReadAllLines(FileName);
        return lines.Select(line =>
        {
            var parts = line.Split("#");
            return new Listing(int.Parse(parts[0].Trim()), parts[1].Trim(), DateTime.Parse(parts[2].Trim()), TimeSpan.Parse(parts[3].Trim()), decimal.Parse(parts[4].Trim()), bool.Parse(parts[5].Trim()));
        }).ToList();
    }

    public void SaveListings()
    {
        var lines = listings.Select(listing => listing.ToString()).ToArray();
        File.WriteAllLines(FileName, lines);
    }

    public void AddListing(Listing listing)
    {
        listings.Add(listing);
        SaveListings();
    }

    public void EditListing(Listing updatedListing)
    {
        var index = listings.FindIndex(listing => listing.ListingID == updatedListing.ListingID);
        if (index != -1)
        {
            listings[index] = updatedListing;
            SaveListings();
        }
    }

    public void DeleteListing(int listingID)
    {
        var index = listings.FindIndex(listing => listing.ListingID == listingID);
        if (index != -1)
        {
            listings.RemoveAt(index);
            SaveListings();
        }
    }
    }
}