using Common.Domain.Model.Interface;
using Common.Presentation.View;
using UniRx;

namespace Common.Presentation.Presenter
{
    public sealed class LevelPresenter
    {
        public LevelPresenter(ILevelModel levelModel, LevelView levelView)
        {
            levelModel.level
                .Subscribe(levelView.DisplayLevel)
                .AddTo(levelView);
        }
    }
}