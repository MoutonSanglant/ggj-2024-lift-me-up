using System;
using System.Linq;
using HelloGameDev;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LiftMeUp
{
    public class ColorPaletteManager : MonoBehaviour
    {
        [SerializeField] private Mood StartMood;
        [field: SerializeField] public Palette[] Palettes { get; private set; }

        public static ColorPaletteManager Instance { get; private set; }

        public static Action<Palette> OnPaletteChange = _ => { };

        private void Awake()
        {
            Instance = this;

            SwitchPalette(StartMood);

            SceneTransitionManager.OnSceneWillChange += () =>
            {
                OnPaletteChange = _ => { };
            };
        }

        public static void SwitchPalette(Mood mood)
        {
            var palette = Instance.Palettes.FirstOrDefault(palette => palette.Mood == mood);

            if (palette == null)
            {
                Debug.LogWarning($"Trying to switch to unavailable palette \"{mood}\"");
                return;
            }

            OnPaletteChange.Invoke(palette);
        }

        [Serializable]
        public class Palette
        {
            public Mood Mood;

            public Color MainColor;
            public Color SecondaryColor;
            public Color AccentColor;
            public Color ShadowColor;
        }

        public enum Mood
        {
            Neutral,
            Happy,
            Sad,
            Angry,
            GameOver,
        }

        public enum ColorIndex
        {
            MainColor,
            SecondaryColor,
            AccentColor,
            ShadowColor,
        }
    }
}
