namespace Games.Task3WinnerScore;
public class WinnerScore
{
    public static string PredictWinner( string team1Name, string team2Name, string score, int n)
    {
        int[] count = new int[2];
        for (int i = 0; i < score.Length; i++)
        {
            count[score[i] - '0']++;

            if (count[0] == n && count[1] < n - 1 ||
                count[0] > 14 && count[0] - count[1] == 2)
            {
                return $"{team1Name} beat {team2Name} {count[0]}-{count[1]}";
            }

            if (count[1] == n && count[0] < n - 1 ||
                count[1] > 14 && count[1] - count[0] == 2)
            {
                return $"{team1Name} beat {team2Name} {count[1]}-{count[0]}";
            }
        }

        return "No winner";
    }
}
