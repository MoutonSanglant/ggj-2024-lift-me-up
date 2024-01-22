using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HelloGameDev.Views
{
    public class CreditsView : MonoBehaviour, IPointerClickHandler
    {
        // URLs to open when links clicked
        private const string MewMewPixelFontHomePageUrl = "https://mewmewdevart.itch.io/minimal-font-in-pixelart";

        [SerializeField, Tooltip("The UI GameObject having the TextMesh Pro component.")]
        private TMP_Text Text = default;

        [SerializeField] private Transform LicensePanel;

        #region Licenses

        private Dictionary<string, string> _licenses = new Dictionary<string, string>
        {
            { "MewMewPixelFontLicense", @"**MewmewDevart Minimal V01 PixelArt Font Free Use License Agreement**
This MewmewDevart Minimal PixelArt Font Free Use License Agreement (""Agreement"") is entered into on October 21, 2023, by and between Larissa Cristina Benedito, known as ""MewmewDevart"" (""Licensor"") and any individual or entity (""Licensee"") who wishes to use the pixel art font created by the Licensor, known as ""MewmewDevart Minimal"" (""Font"").
**1. Grant of License**
Subject to the terms and conditions of this Agreement, Licensor grants Licensee a worldwide, non-exclusive, non-transferable, and non-sublicensable license to use the MewmewDevart Minimal Font for non-commercial purposes only. Licensee may use the Font for personal projects, educational purposes, and non-commercial games or applications.
**2. Restrictions**
Licensee is expressly prohibited from the following actions:
a. Selling, licensing, or distributing the MewmewDevart Minimal Font as a standalone product or as part of any commercial product.
b. Using the Font for any commercial purpose, including, but not limited to, advertising, marketing, or for-profit games or applications.
c. Modifying or altering the Font in any way that results in redistribution, sublicensing, or commercial use.
**3. Ownership and Copyright**
Licensor, Larissa Cristina Benedito, known as ""MewmewDevart,"" retains all rights, title, and interest in and to the MewmewDevart Minimal Font, including all intellectual property rights. This Agreement does not grant Licensee any ownership rights to the Font.
**4. No Warranty**
The MewmewDevart Minimal Font is provided ""as is"" without warranty of any kind, express or implied. Licensor makes no representations or warranties regarding the Font's fitness for a particular purpose or its suitability for any use.
**5. Termination**
This Agreement is effective until terminated by either party. Licensor may terminate this Agreement immediately upon Licensee's breach of any of its terms. Upon termination, Licensee must cease using the MewmewDevart Minimal Font and destroy all copies in their possession.
**6. Governing Law**
This Agreement shall be governed by and construed in accordance with the laws of [Your Jurisdiction]. Any disputes arising from this Agreement shall be resolved in the courts of [Your Jurisdiction].
**7. Entire Agreement**
This Agreement constitutes the entire agreement between the parties and supersedes all prior or contemporaneous understandings or agreements, whether written or oral.
**8. Acceptance**
By using the MewmewDevart Minimal Font, Licensee acknowledges and agrees to be bound by the terms and conditions of this Agreement.
*Licensor: Larissa Cristina Benedito, also known as ""MewmewDevart""*
*Licensee: Any Individual or Entity*
*Date: October 21, 2023*
This Agreement is a legally binding contract. Please read and understand it carefully before using the MewmewDevart Minimal Font. If you do not agree with the terms and conditions of this Agreement, do not use the Font.
" },
        };

        #endregion

        // Callback for handling clicks.
        public void OnPointerClick(PointerEventData eventData)
        {
            // First, get the index of the link clicked. Each of the links in the text has its own index.
            var linkIndex = TMP_TextUtilities.FindIntersectingLink(Text, Input.mousePosition, null);

            if (linkIndex < 0 || linkIndex >= Text.textInfo.linkInfo.Length)
                return;

            // As the order of the links can vary easily (e.g. because of multi-language support),
            // you need to get the ID assigned to the links instead of using the index as a base for our decisions.
            // you need the LinkInfo array from the textInfo member of the TextMesh Pro object for that.
            var linkId = Text.textInfo.linkInfo[linkIndex].GetLinkID();

            // Now finally you have the ID in hand to decide what to do. Don't forget,
            // you don't need to make it act like an actual link, instead of opening a web page,
            // any kind of functions can be called.

            if (linkId.EndsWith("License"))
            {
                var canvasGroup = LicensePanel.GetComponent<CanvasGroup>();

                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;

                LicensePanel.GetComponentInChildren<TMP_Text>().text = _licenses[linkId];
                LicensePanel.gameObject.SetActive(true);
            }
            else
            {

                var url = linkId switch
                {
                    "MewMewPixelFontHome" => MewMewPixelFontHomePageUrl,
                    _ => ""
                };

                Application.OpenURL(url);
            }
        }
    }
}