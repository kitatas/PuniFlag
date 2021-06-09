using Kai.Common.Domain.UseCase.Interface;
using Kai.Result.Domain.UseCase.Interface;
using Kai.Result.Presentation.View;

namespace Kai.Result.Presentation.Presenter
{
    public sealed class RankingScreenPresenter
    {
        public RankingScreenPresenter(IRankingScreenUseCase rankingScreenUseCase, RankingScreenView rankingScreenView,
            IStepCountUseCase stepCountUseCase, TweetButton tweetButton)
        {
            rankingScreenView.Show(rankingScreenUseCase.rankingScreen);
            tweetButton.Init(rankingScreenUseCase.language, stepCountUseCase.GetStepCount());
        }
    }
}