using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HelloGameDev.Localization
{
    public class LocalizationManager : MonoBehaviour
    {
        public Action<Language> OnLanguageChange = _ => { };

        [SerializeField] private Language DefaultLanguage;

        public Language ActiveLanguage { get; private set; }
        public static LocalizationManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            SetLanguage(DefaultLanguage);
            DontDestroyOnLoad(gameObject);
        }

        public static void SetLanguage(Language language)
        {
            Instance.ActiveLanguage = language;
            Instance.OnLanguageChange.Invoke(language);
        }

        public static string GetLocalizedText(IEnumerable<Locale> locales)
        {
            var locale = locales.FirstOrDefault(locale => locale.Language == Instance.ActiveLanguage);

            return locale == null ? "" : locale.Value;
        }

        [Serializable]
        public class Locale
        {
            public Language Language;
            [TextArea]
            public string Value;
        }

        public enum Language
        {
            English,
            French,
        }
    }
}
