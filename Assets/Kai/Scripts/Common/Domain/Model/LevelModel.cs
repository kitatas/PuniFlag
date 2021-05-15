using Kai.Common.Domain.Model.Interface;
using UniRx;

namespace Kai.Common.Domain.Model
{
    public sealed class LevelModel : ILevelModel
    {
        private readonly ReactiveProperty<int> _level;

        public LevelModel()
        {
            _level = new ReactiveProperty<int>(0);
        }

        public IReadOnlyReactiveProperty<int> level => _level;

        public void SetLevel(int value) => _level.Value = value;
    }
}