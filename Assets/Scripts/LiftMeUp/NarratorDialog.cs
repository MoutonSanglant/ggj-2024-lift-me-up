using System;
using HelloGameDev.Localization;
using UnityEngine;

namespace LiftMeUp
{
    [CreateAssetMenu(fileName = "NarratorDialog", menuName = "LiftMeUp/NarratorDialog")]
    public class NarratorDialog : ScriptableObject
    {
        [field: SerializeField] public int Floor { get; private set; }
        [field: SerializeField] public ColorPaletteManager.Mood Mood { get; private set; }
        [field: SerializeField] public LiftExpressionManager.State Expression { get; private set; }
        [SerializeField] private LocalizationManager.Locale[] Locales =
        {
            new() { Language = LocalizationManager.Language.English },
            new() { Language = LocalizationManager.Language.French },
        };

        [field: SerializeField]
        public PlayerAnswer[] PlayerAnswers { get; private set; } =
        {
            new()
            {
                Locales = new LocalizationManager.Locale[]
                {
                    new() { Language = LocalizationManager.Language.English },
                    new() { Language = LocalizationManager.Language.French },
                },
                PostSelectionLocales = new LocalizationManager.Locale[]
                {
                    new() { Language = LocalizationManager.Language.English },
                    new() { Language = LocalizationManager.Language.French },
                },
                PostSelectionButtonLocales = new LocalizationManager.Locale[]
                {
                    new() { Language = LocalizationManager.Language.English, Value = "..." },
                    new() { Language = LocalizationManager.Language.French, Value = "..."},
                },
            },
        };

        public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);

        [Serializable]
        public class PlayerAnswer
        {
            [field: SerializeField] public bool BackToTitleScreen { get; private set; }
            [field: SerializeField] public NarratorDialog NextDialog { get; private set; }
            [field: SerializeField] public int Score { get; private set; }
            [field: SerializeField] public ColorPaletteManager.Mood Mood { get; private set; }
            [field: SerializeField] public LiftExpressionManager.State Expression { get; private set; }
            public LocalizationManager.Locale[] Locales;
            public LocalizationManager.Locale[] PostSelectionLocales;
            public LocalizationManager.Locale[] PostSelectionButtonLocales;

            public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);
            public string PostSelectionLocalizedText => LocalizationManager.GetLocalizedText(PostSelectionLocales);
            public string PostSelectionButtonLocalizedText => LocalizationManager.GetLocalizedText(PostSelectionButtonLocales);
        }
    }
}
