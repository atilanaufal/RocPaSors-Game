
namespace RocPaSors
{
    internal class MatchCounter
    {
        public static byte opScoreCounter = 0;
        public static byte plyrScoreCounter = 0;
        public static byte roundCounter = 1;
        public static byte[] opCount = { 0, 0, 0, 0, 0 };
        public static byte[] plyrCount = { 0, 0, 0, 0, 0 };
        public static byte[] roCount = { 0, 0, 0, 0, 0 };
        GameMatch win;
        public MatchCounter(GameMatch win)
        {
            this.win = win;
        }
        public void startPlayerCounter()
        {
            
            plyrScoreCounter++;
            plyrCount[roundCounter - 1] = 1;
            win.PlayerScore.Text = $"{plyrScoreCounter}";      
        }
        public void startOpponentCounter()
        {
           
            opScoreCounter++;
            opCount[roundCounter - 1] = 1;
            win.OpponentScore.Text = $"{opScoreCounter}";
        }
        public void startRoundCounter()
        {
            roCount[roundCounter - 1] = roundCounter;                      
            roundCounter++;
            if (roundCounter == 5) roCount[4] = roundCounter;
            win.Round.Text = roundCounter.ToString();                        
        }
        public void ResetAllCounter()
        {
            plyrScoreCounter = 0;
            win.PlayerScore.Text = $"{plyrScoreCounter}";
            roundCounter = 1;
            win.Round.Text = $"{roundCounter}";
            opScoreCounter = 0;
            win.OpponentScore.Text = $"{opScoreCounter}";
            opCount = new byte[] { 0, 0, 0, 0, 0 };
            plyrCount = new byte[] { 0, 0, 0, 0, 0 };
            roCount = new byte[] { 0, 0, 0, 0, 0 };
    }
    }
}
