using System;
using System.Collections;
using HelloGameDev;
using HelloGameDev.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LiftMeUp
{
    public class Narrator : MonoBehaviour
    {
        [SerializeField] private TMP_Text NarratorPanel;
        [SerializeField] private Image DialogAvatar;
        [SerializeField] private Image LiftAvatar;
        [SerializeField] private TMP_Text[] PlayerAnswersButtons;
        [SerializeField] private TMP_Text FloorDisplay;
        [SerializeField] private Animator TransitionAnimator;
        [SerializeField] private float TransitionDuration = 0.6f;
        [SerializeField] private Sprite TransitionExpression;
        [SerializeField] private LocalizationManager.Locale[] TransitionDisplayedMessage;
        [SerializeField] private AudioSource MusicSource;
        [SerializeField] private AudioClip ThemeCalm;
        [SerializeField] private AudioClip ThemeHappy;
        [SerializeField] private AudioClip ThemeSad;
        [SerializeField] private AudioClip ThemeAngry;
        [SerializeField] private AudioSource SfxSource;
        [SerializeField] private AudioClip SfxDing;
        [SerializeField] private AudioClip SfxLiftMove;

        [SerializeField] private NarratorDialog StartDialog;
        private static readonly int IsLifting = Animator.StringToHash("isLifting");

        public static Action<int> onScoreChange = _ => { };

        private int _score;

        public static Narrator Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SetDialog(StartDialog);

            _score = 0;
        }

        public static void SetDialog(NarratorDialog dialog)
        {
            Instance.DisplayDialog(dialog);
        }

        private void DisplayDialog(NarratorDialog dialog)
        {
            NarratorPanel.text = LocalizationManager.GetLocalizedText(TransitionDisplayedMessage);
            DialogAvatar.sprite = TransitionExpression;
            LiftAvatar.sprite = TransitionExpression;

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
                        DisplayPostAnswerDialog(answer);
                    });
                }
            }

            var currentFloor = int.Parse(FloorDisplay.text);

            if (dialog.Floor != currentFloor)
                StartCoroutine(FloorTransition(TransitionDuration, dialog, DisplayNextDialog));
            else
                DisplayNextDialog();

            return;


            void DisplayPostAnswerDialog(NarratorDialog.PlayerAnswer answer)
            {
                if (answer.BackToTitleScreen)
                {
                    SceneTransitionManager.LoadScene(SceneTransitionManager.Scene.Title);

                    return;
                }

                var expression = LiftExpressionManager.GetSpriteFromState(answer.Expression);

                _score += answer.Score;
                onScoreChange.Invoke(_score);
                LiftAvatar.sprite = expression;
                DialogAvatar.sprite = expression;
                NarratorPanel.text = answer.PostSelectionLocalizedText;
                ColorPaletteManager.SwitchPalette(answer.Mood);
                PlayTheme(answer.Mood);

                for (var i = 0; i < PlayerAnswersButtons.Length; i++)
                {
                    var buttonText = PlayerAnswersButtons[i];
                    var buttonTransform = buttonText.transform.parent;

                    if (i == 0)
                    {
                        var button = buttonTransform.GetComponent<Button>();

                        buttonText.text = answer.PostSelectionButtonLocalizedText;

                        buttonTransform.gameObject.SetActive(true);

                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() =>
                        {
                            SetDialog(answer.NextDialog);
                        });
                    }
                    else
                        buttonTransform.gameObject.SetActive(false);
                }
            }

            void DisplayNextDialog()
            {
                var expression = LiftExpressionManager.GetSpriteFromState(dialog.Expression);

                LiftAvatar.sprite = expression;
                DialogAvatar.sprite = expression;
                NarratorPanel.text = dialog.LocalizedText;
                FloorDisplay.text = dialog.Floor.ToString();
                ColorPaletteManager.SwitchPalette(dialog.Mood);
                PlayTheme(dialog.Mood);

                for (var i = 0; i < PlayerAnswersButtons.Length; i++)
                {
                    if (i >= dialog.PlayerAnswers.Length) continue;

                    var buttonText = PlayerAnswersButtons[i];
                    var buttonTransform = buttonText.transform.parent;

                    buttonTransform.gameObject.SetActive(true);
                }
            }
        }

        private IEnumerator FloorTransition(float duration, NarratorDialog dialog, Action callback)
        {
            TransitionAnimator.SetBool(IsLifting, true);

            SfxSource.clip = SfxLiftMove;
            SfxSource.Play();

            var elapsed = 0f;
            var currentFloor = int.Parse(FloorDisplay.text);
            var targetFloor = dialog.Floor;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                FloorDisplay.text = Mathf.Floor(Mathf.Lerp(currentFloor, targetFloor, elapsed / duration)).ToString();

                yield return null;
            }

            FloorDisplay.text = targetFloor.ToString();
            TransitionAnimator.SetBool(IsLifting, false);

            SfxSource.Stop();
            SfxSource.PlayOneShot(SfxDing);

            callback.Invoke();
        }

        private void PlayTheme(ColorPaletteManager.Mood mood)
        {
            var clip = GetTheme(mood);

            if (clip != MusicSource.clip)
            {
                MusicSource.Stop();
                MusicSource.clip = clip;
                MusicSource.Play();
            }
        }

        private AudioClip GetTheme(ColorPaletteManager.Mood mood)
        {
            return mood switch
            {
                ColorPaletteManager.Mood.Neutral => ThemeCalm,
                ColorPaletteManager.Mood.Happy => ThemeHappy,
                ColorPaletteManager.Mood.Sad => ThemeSad,
                ColorPaletteManager.Mood.Angry => ThemeAngry,
                ColorPaletteManager.Mood.GameOver => ThemeAngry,
                _ => ThemeCalm
            };
        }
    }
}
