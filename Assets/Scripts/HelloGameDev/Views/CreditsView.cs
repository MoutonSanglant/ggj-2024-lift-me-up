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
        private const string ObsidianMelodiaSoundtrack1Url = "https://www.youtube.com/watch?v=oGtJ7A8AC7Q";
        private const string ObsidianMelodiaSoundtrack2Url = "https://www.youtube.com/watch?v=hJncFeJDD_k";
        private const string ObsidianMelodiaSoundtrack3Url = "https://www.youtube.com/watch?v=EGaMI9s_Mzc";
        private const string ObsidianMelodiaSoundtrack4Url = "https://www.youtube.com/watch?v=fhTKwA0PBE0";

        [SerializeField, Tooltip("The UI GameObject having the TextMesh Pro component.")]
        private TMP_Text Text = default;

        [SerializeField] private Transform LicensePanel;

        #region Licenses

        private Dictionary<string, string> _licenses = new Dictionary<string, string>
        {
            {
                "MewMewPixelFontLicense",
                @"**MewmewDevart Minimal V01 PixelArt Font Free Use License Agreement**
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
"
            },
            {
                "ConnectionSerifFontLicense",
                @"Copyright (c) 2017, Jasper @ KineticPlasma Fonts (cannotintospacefonts@gmail.com),
with Reserved Font Name Connection Serif.

This Font Software is licensed under the SIL Open Font License, Version 1.1.
This license is copied below, and is also available with a FAQ at:
http://scripts.sil.org/OFL


-----------------------------------------------------------
SIL OPEN FONT LICENSE Version 1.1 - 26 February 2007
-----------------------------------------------------------

PREAMBLE
The goals of the Open Font License (OFL) are to stimulate worldwide
development of collaborative font projects, to support the font creation
efforts of academic and linguistic communities, and to provide a free and
open framework in which fonts may be shared and improved in partnership
with others.

The OFL allows the licensed fonts to be used, studied, modified and
redistributed freely as long as they are not sold by themselves. The
fonts, including any derivative works, can be bundled, embedded,
redistributed and/or sold with any software provided that any reserved
names are not used by derivative works. The fonts and derivatives,
however, cannot be released under any other type of license. The
requirement for fonts to remain under this license does not apply
to any document created using the fonts or their derivatives.

DEFINITIONS
""Font Software"" refers to the set of files released by the Copyright
Holder(s) under this license and clearly marked as such. This may
include source files, build scripts and documentation.

""Reserved Font Name"" refers to any names specified as such after the
copyright statement(s).

""Original Version"" refers to the collection of Font Software components as
distributed by the Copyright Holder(s).

""Modified Version"" refers to any derivative made by adding to, deleting,
or substituting -- in part or in whole -- any of the components of the
Original Version, by changing formats or by porting the Font Software to a
new environment.

""Author"" refers to any designer, engineer, programmer, technical
writer or other person who contributed to the Font Software.

PERMISSION & CONDITIONS
Permission is hereby granted, free of charge, to any person obtaining
a copy of the Font Software, to use, study, copy, merge, embed, modify,
redistribute, and sell modified and unmodified copies of the Font
Software, subject to the following conditions:

1) Neither the Font Software nor any of its individual components,
in Original or Modified Versions, may be sold by itself.

2) Original or Modified Versions of the Font Software may be bundled,
redistributed and/or sold with any software, provided that each copy
contains the above copyright notice and this license. These can be
included either as stand-alone text files, human-readable headers or
in the appropriate machine-readable metadata fields within text or
binary files as long as those fields can be easily viewed by the user.

3) No Modified Version of the Font Software may use the Reserved Font
Name(s) unless explicit written permission is granted by the corresponding
Copyright Holder. This restriction only applies to the primary font name as
presented to the users.

4) The name(s) of the Copyright Holder(s) or the Author(s) of the Font
Software shall not be used to promote, endorse or advertise any
Modified Version, except to acknowledge the contribution(s) of the
Copyright Holder(s) and the Author(s) or with their explicit written
permission.

5) The Font Software, modified or unmodified, in part or in whole,
must be distributed entirely under this license, and must not be
distributed under any other license. The requirement for fonts to
remain under this license does not apply to any document created
using the Font Software.

TERMINATION
This license becomes null and void if any of the above conditions are
not met.

DISCLAIMER
THE FONT SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO ANY WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT
OF COPYRIGHT, PATENT, TRADEMARK, OR OTHER RIGHT. IN NO EVENT SHALL THE
COPYRIGHT HOLDER BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
INCLUDING ANY GENERAL, SPECIAL, INDIRECT, INCIDENTAL, OR CONSEQUENTIAL
DAMAGES, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF THE USE OR INABILITY TO USE THE FONT SOFTWARE OR FROM
OTHER DEALINGS IN THE FONT SOFTWARE."
            },
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
                    "ObsidianMelodiaSoundtrack1" => ObsidianMelodiaSoundtrack1Url,
                    "ObsidianMelodiaSoundtrack2" => ObsidianMelodiaSoundtrack2Url,
                    "ObsidianMelodiaSoundtrack3" => ObsidianMelodiaSoundtrack3Url,
                    "ObsidianMelodiaSoundtrack4" => ObsidianMelodiaSoundtrack4Url,
                    _ => ""
                };

                Application.OpenURL(url);
            }
        }
    }
}