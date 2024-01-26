namespace Games.Task6API.Data;
public class ScoreRecord
{
    public ScoreRecord()
    {
        this.Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Team1Name { get; set; } = string.Empty;
    public string Team2Name { get; set; } = string.Empty;
    public string ScoreInput { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
}