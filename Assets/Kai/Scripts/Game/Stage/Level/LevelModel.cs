using Common;
using UniRx;

namespace Game.Stage.Level
{
    public sealed class LevelModel
    {
        private readonly ReactiveProperty<int> _level;

        public LevelModel()
        {
            _level = new ReactiveProperty<int>(0);
        }

        public IReadOnlyReactiveProperty<int> level => _level;

        public int GetLevel() => level.Value;

        private void SetLevel(int value) => _level.Value = value;

        public void LevelUp()
        {
            var nextLevel = GetLevel() + 1;
            var loadLevel = nextLevel < Const.STAGE_COUNT ? nextLevel : 0;
            SetLevel(loadLevel);
        }

        public void ResetLevel() => SetLevel(0);
    }
}