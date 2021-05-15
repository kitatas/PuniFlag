using Common.Data.Entity.Interface;
using Common.Domain.Model.Interface;
using Common.Domain.UseCase.Interface;

namespace Common.Domain.UseCase
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

        public void CountUp()
        {
            _levelEntity.LevelUp();
            _levelModel.SetLevel(GetLevel());
        }

        public void ResetLevel()
        {
            _levelEntity.ResetLevel();
            _levelModel.SetLevel(GetLevel());
        }
    }
}