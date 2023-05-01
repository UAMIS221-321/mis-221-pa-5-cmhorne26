namespace mis_221_pa_5_cmhorne26
{
    public class TrainerManager
    {
        
    private const string FileName = "trainers.txt";
    private List<Trainer> trainers;

    public TrainerManager()
    {
        trainers = LoadTrainers();
    }

    public List<Trainer> LoadTrainers()
    {
        if (!File.Exists(FileName))
        {
            return new List<Trainer>();
        }

        var lines = File.ReadAllLines(FileName);
        return lines.Select(line =>
        {
            var parts = line.Split("#");
            return new Trainer(int.Parse(parts[0].Trim()), parts[1].Trim(), parts[2].Trim(), parts[3].Trim());
        }).ToList();
    }

    public void SaveTrainers()
    {
        var lines = trainers.Select(trainer => trainer.ToString()).ToArray();
        File.WriteAllLines(FileName, lines);
    }

    public void AddTrainer(Trainer trainer)
    {
        trainers.Add(trainer);
        SaveTrainers();
    }

    public void EditTrainer(Trainer updatedTrainer)
    {
        var index = trainers.FindIndex(trainer => trainer.TrainerID == updatedTrainer.TrainerID);
        if (index != -1)
        {
            trainers[index] = updatedTrainer;
            SaveTrainers();
        }
    }

    public void DeleteTrainer(int trainerID)
    {
        var index = trainers.FindIndex(trainer => trainer.TrainerID == trainerID);
        if (index != -1)
        {
            trainers.RemoveAt(index);
            SaveTrainers();
        }
    }
    }
}