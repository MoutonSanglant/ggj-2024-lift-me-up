using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace HelloGameDev.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedLabel : MonoBehaviour
    {
        [SerializeField] private Locale[] Locales;

        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            LocalizationManager.Instance.OnLanguageChange += UpdateText;
        }

        public void UpdateText(LocalizationManager.Language language)
        {
            var locale = Locales.FirstOrDefault(locale => locale.Language == language);

            if (locale == null)
                return;

            _text.text = locale.Value;
        }

        [Serializable]
        public class Locale
        {
            public LocalizationManager.Language Language;
            public string Value;
        }
    }
}
