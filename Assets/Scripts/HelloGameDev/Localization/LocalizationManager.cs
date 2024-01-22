using System;
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
            Instance = this;

            SetLanguage(DefaultLanguage);
            DontDestroyOnLoad(gameObject);
        }

        public static void SetLanguage(Language language)
        {
            Instance.ActiveLanguage = language;
            Instance.OnLanguageChange.Invoke(language);
        }

        public enum Language
        {
            English,
            French,
        }
    }
}
