using System;
using Flappybird.Scripts.Core.Patterns;
using Flappybird.Scripts.Core.Services;

namespace Flappybird.Scripts.Gameplay.Points
{
    public class PointManager : MonoBehaviourSingleton<PointManager>
    {
        public int score;
        
        public static Action<int> onScoreChanged;

        private void Start()
        {
            score = 0;
            onScoreChanged?.Invoke(score);
        }

        
        public void UpdateScore()
        {
            score++;
            onScoreChanged?.Invoke(score);
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