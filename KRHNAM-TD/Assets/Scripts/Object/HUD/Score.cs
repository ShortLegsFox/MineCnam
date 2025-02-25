namespace TDObject.HUD
{
    public class Score
    {
        public string PlayerName;
        public int Points;


        public Score(string playerName, int score)
        {
            PlayerName = playerName;
            Points = score;
        }

    }
}
