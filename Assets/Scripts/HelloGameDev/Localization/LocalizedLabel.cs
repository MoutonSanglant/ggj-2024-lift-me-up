using System.Linq;
using TMPro;
using UnityEngine;

namespace HelloGameDev.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedLabel : MonoBehaviour
    {
        private const string MissingLocaleText = "MISSING_LOCALE";

        [SerializeField] private LocalizationManager.Locale[] Locales;

        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            LocalizationManager.Instance.OnLanguageChange += UpdateText;
        }

        private void UpdateText(LocalizationManager.Language language)
        {
            var locale = Locales.FirstOrDefault(locale => locale.Language == language);

            _text.text = (locale == null) ? MissingLocaleText : locale.Value;
        }
    }
}
