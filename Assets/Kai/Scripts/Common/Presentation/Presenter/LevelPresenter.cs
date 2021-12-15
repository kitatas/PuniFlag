using Kai.Common.Domain.Model.Interface;
using Kai.Common.Presentation.View;
using UniRx;

namespace Kai.Common.Presentation.Presenter
{
    public sealed class LevelPresenter
    {
        public LevelPresenter(ILevelModel levelModel, IGameTypeModel gameTypeModel, LevelView levelView)
        {
            levelModel.level
                .Subscribe(levelView.DisplayLevel)
                .AddTo(levelView);

            gameTypeModel.gameType
                .Subscribe(levelView.UpdateDigit)
                .AddTo(levelView);
        }
    }
}