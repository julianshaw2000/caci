namespace Games.Task1Refactor;

public class SportRefactor
{
public static string PredictWinner(string score, int n)
{
    ScoreTracker tracker = new ScoreTracker(score, n);
    tracker.ProcessScore();

    return tracker.ResultMessage;
}
}

internal class ScoreTracker
{
private readonly string score;
private readonly int n;
public string ResultMessage { get; set; } = string.Empty;

internal ScoreTracker(string score, int n)
{
    this.score = score;
    this.n = n;
}

internal void ProcessScore()
{
    int[] count = new int[2];
    int i;
    for (i = 0; i < score.Length; i++)
    {
        count[score[i] - '0']++;

        if (CheckLosingCondition(count))
        {
            ResultMessage = "Team 1 lost";
            return;
        }

        if (CheckWinningCondition(count))
        {
            ResultMessage = "Team 1 won";
            return;
        }

        ResetCountsIfTie(count);
    }

    ProcessPostTieScore(count);
}

private bool CheckLosingCondition(int[] count)
{
    return count[0] == n && count[1] < n - 1;
}

private bool CheckWinningCondition(int[] count)
{
    return count[1] == n && count[0] < n - 1;
}

private void ResetCountsIfTie(int[] count)
{
    if (count[0] == n - 1 && count[1] == n - 1)
    {
        count[0] = 0;
        count[1] = 0;
    }
}

private void ProcessPostTieScore(int[] count)
{
    for (int i = 0; i < score.Length; i++)
    {
        count[score[i] - '0']++;
        if (Math.Abs(count[0] - count[1]) == 2)
        {
            ResultMessage = count[0] > count[1] ? "Team 1 lost" : "Team 1 won";
            return;
        }
    }
}
}