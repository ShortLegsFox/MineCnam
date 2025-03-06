namespace TDObject.HUD
{
    [System.Serializable]
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
