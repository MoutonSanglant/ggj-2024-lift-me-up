using System;
using HelloGameDev.Localization;
using UnityEngine;

namespace LiftMeUp
{
    [CreateAssetMenu(fileName = "NarratorDialog", menuName = "LiftMeUp/NarratorDialog")]
    public class NarratorDialog : ScriptableObject
    {
        [SerializeField] private LocalizationManager.Locale[] Locales =
        {
            new() { Language = LocalizationManager.Language.English },
            new() { Language = LocalizationManager.Language.French },
        };
        [field: SerializeField] public LiftExpressionManager.State LiftState { get; private set; }

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
                    new() { Language = LocalizationManager.Language.English },
                    new() { Language = LocalizationManager.Language.French },
                },
            },
        };
        [field: SerializeField] public int Floor { get; private set; }
        [field: SerializeField] public ColorPaletteManager.Mood Mood { get; private set; }
        [field: SerializeField] public bool PlayLiftAnimation { get; private set; } = true;

        public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);

        [Serializable]
        public class PlayerAnswer
        {
            public LocalizationManager.Locale[] Locales;
            public LocalizationManager.Locale[] PostSelectionLocales;
            public LocalizationManager.Locale[] PostSelectionButtonLocales;
            public NarratorDialog NextDialog;
            [field: SerializeField] public LiftExpressionManager.State LiftState { get; private set; }
            [field: SerializeField] public ColorPaletteManager.Mood Mood { get; private set; }

            public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);
            public string PostSelectionLocalizedText => LocalizationManager.GetLocalizedText(PostSelectionLocales);
            public string PostSelectionButtonLocalizedText => LocalizationManager.GetLocalizedText(PostSelectionButtonLocales);
        }
    }
}
