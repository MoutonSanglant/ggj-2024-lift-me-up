using System;
using TMPro;
using UnityEngine;

namespace LiftMeUp
{
    public class TrackTitleDisplay : MonoBehaviour
    {
        [Header("Required References")]
        [SerializeField] private TMP_Text TrackTitleLabel;

        private void Awake()
        {
            ColorPaletteManager.OnMoodChange += UpdateMusicTitleLabel;
        }

        private void OnDestroy()
        {
            ColorPaletteManager.OnMoodChange -= UpdateMusicTitleLabel;
        }

        private void UpdateMusicTitleLabel(ColorPaletteManager.Mood mood)
        {
            TrackTitleLabel.text = MusicTitleFromMood(mood);
        }

        private static string MusicTitleFromMood(ColorPaletteManager.Mood mood)
        {
            return mood switch
            {
                ColorPaletteManager.Mood.Neutral => "Silent Mechanics",
                ColorPaletteManager.Mood.Happy => "Joyful Ascent",
                ColorPaletteManager.Mood.Sad => "Tears In The Descent",
                ColorPaletteManager.Mood.Angry => "Voltage Outburst",
                ColorPaletteManager.Mood.GameOver => "Tears In The Descent",
                _ => throw new ArgumentOutOfRangeException(nameof(mood), mood, null)
            };
        }
    }
}
