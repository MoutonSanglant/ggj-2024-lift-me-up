using System;
using System.Collections;
using HelloGameDev.Localization;
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
        [SerializeField] private Animator TransitionAnimator;
        [SerializeField] private float TransitionDuration = 0.6f;
        [SerializeField] private Sprite TransitionExpression;
        [SerializeField] private LocalizationManager.Locale[] TransitionDisplayedMessage;

        [SerializeField] private NarratorDialog StartDialog;
        private static readonly int IsLifting = Animator.StringToHash("isLifting");

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
            NarratorPanel.text = LocalizationManager.GetLocalizedText(TransitionDisplayedMessage);
            Avatar.sprite = TransitionExpression;

            for (var i = 0; i < PlayerAnswersButtons.Length; i++)
            {
                var buttonText = PlayerAnswersButtons[i];
                var buttonTransform = buttonText.transform.parent;

                buttonTransform.gameObject.SetActive(false);

                if (i < dialog.PlayerAnswers.Length)
                {
                    var answer = dialog.PlayerAnswers[i];
                    var button = buttonTransform.GetComponent<Button>();

                    buttonText.text = answer.LocalizedText;

                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() =>
                    {
                        SetDialog(answer.NextDialog);
                    });
                }

                if (dialog.PlayLiftAnimation)
                    StartCoroutine(StageTransition(TransitionDuration, dialog, DisplayNextDialog));
                else
                    DisplayNextDialog();
            }

            return;


            void DisplayNextDialog()
            {
                NarratorPanel.text = dialog.LocalizedText;
                Avatar.sprite = dialog.DisplayedAvatar;
                StageDisplay.text = dialog.Stage.ToString();

                for (var i = 0; i < PlayerAnswersButtons.Length; i++)
                {
                    if (i >= dialog.PlayerAnswers.Length) continue;

                    var buttonText = PlayerAnswersButtons[i];
                    var buttonTransform = buttonText.transform.parent;

                    buttonTransform.gameObject.SetActive(true);
                }
            }
        }

        private IEnumerator StageTransition(float duration, NarratorDialog dialog, Action callback)
        {
            TransitionAnimator.SetBool(IsLifting, true);

            // TODO - start lift SFX

            var elapsed = 0f;
            var currentStage = int.Parse(StageDisplay.text);
            var targetStage = dialog.Stage;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                StageDisplay.text = Mathf.Floor(Mathf.Lerp(currentStage, targetStage, elapsed / duration)).ToString();

                yield return null;
            }

            StageDisplay.text = targetStage.ToString();
            TransitionAnimator.SetBool(IsLifting, false);

            // TODO - stop lift SFX and play "ding" SFX

            callback.Invoke();
        }
    }
}
