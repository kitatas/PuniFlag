using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class MenuScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI freePlay = default;
        [SerializeField] private TextMeshProUGUI scoreAttack = default;
        [SerializeField] private TextMeshProUGUI config = default;
        [SerializeField] private TextMeshProUGUI explain = default;
        [SerializeField] private TextMeshProUGUI information = default;

        public void Show(MenuScreen menuScreen)
        {
            freePlay.SetTextData(menuScreen.freePlay);
            scoreAttack.SetTextData(menuScreen.scoreAttack);
            config.SetTextData(menuScreen.config);
            explain.SetTextData(menuScreen.explain);
            information.SetTextData(menuScreen.information);
        }
    }
}