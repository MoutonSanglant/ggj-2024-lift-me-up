using TMPro;
using UnityEngine;

namespace LiftMeUp
{
    public class ScoreCounter : MonoBehaviour
    {
        [Header("Required References")]
        [SerializeField] private TMP_Text ScoreLabel;

        private void Awake()
        {
            Narrator.onScoreChange += UpdateScoreLabel;
        }

        private void OnDestroy()
        {
            Narrator.onScoreChange -= UpdateScoreLabel;
        }

        private void UpdateScoreLabel(int newScore)
        {
            ScoreLabel.text = $"Score: {newScore}";
        }
    }
}
