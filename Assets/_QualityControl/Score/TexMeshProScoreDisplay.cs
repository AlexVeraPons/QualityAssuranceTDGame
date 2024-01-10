using UnityEngine;

namespace TowerDefenseGame.Score
{
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]
    public class TexMeshProScoreDisplay : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI _scoreText;

        private void Awake() {
            _scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        }
        private void OnEnable() {
            ScoreManager.OnScoreChanged += UpdateScoreText;
        }

        private void OnDisable() {
            ScoreManager.OnScoreChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int score) {
            Debug.Log($"TexMeshProScoreDisplay: {score}");
            _scoreText.text = score.ToString();
        }
    }
}
