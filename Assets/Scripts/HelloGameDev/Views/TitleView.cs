using HelloGameDev.Localization;
using UnityEngine;

namespace HelloGameDev.Views
{
    public class TitleView : MonoBehaviour
    {
        private readonly LocalizationManager.Language[] LanguageArray =
        {
            LocalizationManager.Language.English,
            LocalizationManager.Language.French,
        };

        public void StartGame()
        {
            SceneTransitionManager.LoadScene(SceneTransitionManager.Scene.Game);
        }

        public void SetLanguage(int languageIndex)
        {
            if (languageIndex >= LanguageArray.Length)
                return;

            LocalizationManager.SetLanguage(LanguageArray[languageIndex]);
        }
    }
}
