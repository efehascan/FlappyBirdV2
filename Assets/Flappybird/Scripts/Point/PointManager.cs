using Flappybird.Scripts.SingletonPattern;
using Flappybird.Scripts.Managers; 

namespace Flappybird.Scripts.Point
{
    public class PointManager : MonoBehaviourSingleton<PointManager>
    {
        private int score;

        private void Start()
        {
            score = 0;
        }

        
        public void UpdateScore()
        {
            score++;
            SubmitScore();
        }

        
        public int GetScore()
        {
            return score;
        }
        
        public void SubmitScore()
        {
            FileSaveManager.Instance.TrySetNewTopScore(score);
        }
    }
}