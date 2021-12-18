using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class TitleScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI subTitle = default;
        [SerializeField] private TextMeshProUGUI puni = default;
        [SerializeField] private TextMeshProUGUI flag = default;

        public void Show(TitleScreen titleScreen)
        {
            subTitle.SetTextData(titleScreen.subTitle);
            puni.SetTextData(titleScreen.puni);
            flag.SetTextData(titleScreen.flag);
        }
    }
}