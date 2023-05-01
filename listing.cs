namespace mis_221_pa_5_cmhorne26
{
    public class Listing
    {
        public int ListingID
        {
            get; set; 
        }
        public string TrainerName
        {
            get; set;
        }
        public DateTime SessionDate
        {
            get; set;
        }
        public TimeSpan SessionTime
        {
            get; set;
        }
        public decimal SessionCost
        {
            get; set;
        }
        public bool ListingTaken
        {
            get; set;
        }

        public Listing() { }
        public Listing(int id, string trainerName, DateTime sessionDate, TimeSpan sessionTime, decimal sessionCost, bool listingTaken)
        {
        ListingID = id;
        TrainerName = trainerName;
        SessionDate = sessionDate;
        SessionTime = sessionTime;
        SessionCost = sessionCost;
        ListingTaken = listingTaken;
        }

        public override string ToString()
        {
        return $"{ListingID}# {TrainerName}# {SessionDate}# {SessionTime}# {SessionCost}# {ListingTaken}";
        }
    }
}
