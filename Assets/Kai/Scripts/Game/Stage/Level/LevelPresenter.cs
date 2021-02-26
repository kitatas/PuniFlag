using UniRx;

namespace Game.Stage.Level
{
    public sealed class LevelPresenter
    {
        public LevelPresenter(LevelModel levelModel, LevelView levelView)
        {
            levelModel.level
                .Subscribe(levelView.DisplayLevel)
                .AddTo(levelView);
        }
    }
}