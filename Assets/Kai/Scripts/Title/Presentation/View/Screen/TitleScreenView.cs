using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class TitleScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title = default;
        [SerializeField] private TextMeshProUGUI subTitle = default;
        [SerializeField] private TextMeshProUGUI tap = default;

        public void Show(TitleScreen titleScreen)
        {
            title.SetTextData(titleScreen.title);
            subTitle.SetTextData(titleScreen.subTitle);
            tap.SetTextData(titleScreen.tap);
        }
    }
}