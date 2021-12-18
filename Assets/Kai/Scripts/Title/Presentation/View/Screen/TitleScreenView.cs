using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class TitleScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI puni = default;
        [SerializeField] private TextMeshProUGUI flag = default;
        [SerializeField] private RectTransform puniBackground = default;
        [SerializeField] private RectTransform flagBackground = default;

        public void Show(TitleScreen titleScreen)
        {
            puni.SetTextData(titleScreen.puni);
            flag.SetTextData(titleScreen.flag);

            puniBackground.sizeDelta = new Vector2(puni.preferredWidth + 0.2f, puni.preferredHeight + 0.1f);
            flagBackground.sizeDelta = new Vector2(flag.preferredWidth + 0.2f, flag.preferredHeight + 0.1f);
        }
    }
}