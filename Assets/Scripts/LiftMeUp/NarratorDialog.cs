using System;
using System.Linq;
using HelloGameDev.Localization;
using UnityEngine;

namespace LiftMeUp
{
    [CreateAssetMenu(fileName = "NarratorDialog", menuName = "LiftMeUp/NarratorDialog")]
    public class NarratorDialog : ScriptableObject
    {
        [SerializeField] private LocalizationManager.Locale[] Locales;
        [field: SerializeField] public Sprite DisplayedAvatar { get; private set; }
        [field: SerializeField] public PlayerAnswer[] PlayerAnswers { get; private set; }
        [field: SerializeField] public int Stage { get; private set; }

        public string LocalizedText => GetLocalizedText(Locales, LocalizationManager.Instance.ActiveLanguage);

        private static string GetLocalizedText(LocalizationManager.Locale[] locales, LocalizationManager.Language language)
        {
            var locale = locales.FirstOrDefault(locale => locale.Language == language);

            return locale == null ? "" : locale.Value;
        }

        [Serializable]
        public class PlayerAnswer
        {
            public LocalizationManager.Locale[] Locales;
            public NarratorDialog NextDialog;

            public string LocalizedText => GetLocalizedText(Locales, LocalizationManager.Instance.ActiveLanguage);
        }
    }
}
