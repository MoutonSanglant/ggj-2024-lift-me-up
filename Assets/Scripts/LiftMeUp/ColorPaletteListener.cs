using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LiftMeUp
{
    public class ColorPaletteListener : MonoBehaviour
    {
        [SerializeField] private ColorPaletteManager.ColorIndex ColorIndex;

        private Action<Color> TargetAction;

        private void Awake()
        {
            ColorPaletteManager.OnPaletteChange += SetPalette;

            var buttonTarget = GetComponent<Button>();
            var imageTarget = GetComponent<Image>();
            var textTarget = GetComponent<TMP_Text>();

            if (buttonTarget)
            {
                TargetAction += color =>
                {
                    var colors = buttonTarget.colors;
                    colors.normalColor = color;
                    buttonTarget.colors = colors;
                };
            }
            else if (imageTarget)
            {
                TargetAction += color =>
                {
                    imageTarget.color = color;
                };
            }

            if (textTarget)
            {
                TargetAction += color =>
                {
                    textTarget.color = color;
                };
            }
        }

        private void SetPalette(ColorPaletteManager.Palette colorPalette)
        {
            switch (ColorIndex)
            {
                case ColorPaletteManager.ColorIndex.MainColor:
                    TargetAction(colorPalette.MainColor);
                    break;
                case ColorPaletteManager.ColorIndex.SecondaryColor:
                    TargetAction(colorPalette.SecondaryColor);
                    break;
                case ColorPaletteManager.ColorIndex.AccentColor:
                    TargetAction(colorPalette.AccentColor);
                    break;
                case ColorPaletteManager.ColorIndex.ShadowColor:
                    TargetAction(colorPalette.ShadowColor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
