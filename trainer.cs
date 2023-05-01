namespace mis_221_pa_5_cmhorne26
{
    public class Trainer
    {
    public int TrainerID { get; set; }
    public string TrainerName { get; set; }
    public string MailingAddress { get; set; }
    public string TrainerEmail { get; set; }

    public Trainer() { }

    public Trainer(int trainerID, string trainerName, string mailingAddress, string trainerEmail)
    {
        TrainerID = trainerID;
        TrainerName = trainerName;
        MailingAddress = mailingAddress;
        TrainerEmail = trainerEmail;
    }

    public override string ToString()
    {
        return $"{TrainerID}# {TrainerName}# {MailingAddress}# {TrainerEmail}";
    }
    }
}