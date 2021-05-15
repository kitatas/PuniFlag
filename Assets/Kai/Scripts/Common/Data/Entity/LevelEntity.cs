using Kai.Common.Data.Entity.Interface;

namespace Kai.Common.Data.Entity
{
    public sealed class LevelEntity : ILevelEntity
    {
        private int _level;

        public LevelEntity()
        {
            _level = 0;
        }

        public int GetLevel() => _level;

        private void SetLevel(int value) => _level = value;

        public void LevelUp() => SetLevel(GetLevel() + 1);

        public void ResetLevel() => SetLevel(0);
    }
}