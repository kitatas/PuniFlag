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

        public void SetLevel(int value) => _level = value;
    }
}