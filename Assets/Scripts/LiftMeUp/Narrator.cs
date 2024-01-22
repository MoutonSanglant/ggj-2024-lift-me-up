using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LiftMeUp
{
    public class Narrator : MonoBehaviour
    {
        [SerializeField] private TMP_Text NarratorPanel;
        [SerializeField] private Image Avatar;
        [SerializeField] private TMP_Text[] PlayerAnswersButtons;
        [SerializeField] private TMP_Text StageDisplay;

        [SerializeField] private NarratorDialog StartDialog;

        public static Narrator Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SetDialog(StartDialog);
        }

        public static void SetDialog(NarratorDialog dialog)
        {
            Instance.DisplayDialog(dialog);
        }

        private void DisplayDialog(NarratorDialog dialog)
        {
            NarratorPanel.text = dialog.LocalizedText;
            Avatar.sprite = dialog.DisplayedAvatar;

            for (int i = 0; i < PlayerAnswersButtons.Length; i++)
            {
                var buttonText = PlayerAnswersButtons[i];
                var buttonTransform = buttonText.transform.parent;

                if (i < dialog.PlayerAnswers.Length)
                {
                    var answer = dialog.PlayerAnswers[i];
                    var button = buttonTransform.GetComponent<Button>();

                    buttonTransform.gameObject.SetActive(true);
                    buttonText.text = answer.LocalizedText;

                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() =>
                    {
                        SetDialog(answer.NextDialog);
                    });

                    StageDisplay.text = dialog.Stage.ToString();
                }
                else
                    buttonTransform.gameObject.SetActive(false);

            }
        }
    }
}
