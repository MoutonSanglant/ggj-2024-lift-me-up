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
        [field: SerializeField] public LiftExpressionManager.State LiftState { get; private set; }
        [field: SerializeField] public PlayerAnswer[] PlayerAnswers { get; private set; }
        [field: SerializeField] public int Stage { get; private set; }
        [field: SerializeField] public bool PlayLiftAnimation { get; private set; } = true;

        public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);

        [Serializable]
        public class PlayerAnswer
        {
            public LocalizationManager.Locale[] Locales;
            public NarratorDialog NextDialog;

            public string LocalizedText => LocalizationManager.GetLocalizedText(Locales);
        }
    }
}
