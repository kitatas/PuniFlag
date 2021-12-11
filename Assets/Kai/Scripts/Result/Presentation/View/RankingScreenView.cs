using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Result.Presentation.View
{
    public sealed class RankingScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI input = default;
        [SerializeField] private TextMeshProUGUI notice = default;

        public void Show(RankingScreen rankingScreen)
        {
            input.SetTextData(rankingScreen.input);
            notice.SetTextData(rankingScreen.notice);
        }
    }
}