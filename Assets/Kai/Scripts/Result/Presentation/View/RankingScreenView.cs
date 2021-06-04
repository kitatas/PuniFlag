using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Result.Presentation.View
{
    public sealed class RankingScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ranking = default;
        [SerializeField] private TextMeshProUGUI score = default;
        [SerializeField] private TextMeshProUGUI highScore = default;
        [SerializeField] private TextMeshProUGUI tweet = default;
        [SerializeField] private TextMeshProUGUI input = default;
        [SerializeField] private TextMeshProUGUI notice = default;
        [SerializeField] private TextMeshProUGUI send = default;
        [SerializeField] private TextMeshProUGUI back = default;

        public void Show(RankingScreen rankingScreen)
        {
            ranking.SetTextData(rankingScreen.ranking);
            score.SetTextData(rankingScreen.score);
            highScore.SetTextData(rankingScreen.highScore);
            tweet.SetTextData(rankingScreen.tweet);
            input.SetTextData(rankingScreen.input);
            notice.SetTextData(rankingScreen.notice);
            send.SetTextData(rankingScreen.send);
            back.SetTextData(rankingScreen.back);
        }
    }
}