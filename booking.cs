namespace mis_221_pa_5_cmhorne26
{
    public class Booking
    {
        
    public int SessionID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime TrainingDate { get; set; }
    public int TrainerID { get; set; }
    public string TrainerName { get; set; }
    public string Status { get; set; }

    public Booking() { }

    public Booking(int sessionID, string customerName, string customerEmail, DateTime trainingDate, int trainerID, string trainerName, string status)
    {
        SessionID = sessionID;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        TrainingDate = trainingDate;
        TrainerID = trainerID;
        TrainerName = trainerName;
        Status = status;
    }

    public override string ToString()
    {
        return $"{SessionID}# {CustomerName}# {CustomerEmail}# {TrainingDate}# {TrainerID}# {TrainerName}# {Status}";
    }
    }
}