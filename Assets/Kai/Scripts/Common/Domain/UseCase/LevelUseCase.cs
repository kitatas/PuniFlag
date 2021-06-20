using Kai.Common.Data.Entity.Interface;
using Kai.Common.Domain.Model.Interface;
using Kai.Common.Domain.UseCase.Interface;

namespace Kai.Common.Domain.UseCase
{
    public sealed class LevelUseCase : ILevelUseCase
    {
        private readonly ILevelEntity _levelEntity;
        private readonly ILevelModel _levelModel;

        public LevelUseCase(ILevelEntity levelEntity, ILevelModel levelModel)
        {
            _levelEntity = levelEntity;
            _levelModel = levelModel;
        }

        public int GetLevel() => _levelEntity.GetLevel();

        public void SetLevel(int level)
        {
            _levelEntity.SetLevel(level);
            _levelModel.SetLevel(GetLevel());
        }

        public void CountUp()
        {
            SetLevel(GetNextLevel());
        }

        public void ResetLevel()
        {
            SetLevel(0);
        }

        public int GetNextLevel()
        {
            return GetLevel() + 1;
        }
    }
}