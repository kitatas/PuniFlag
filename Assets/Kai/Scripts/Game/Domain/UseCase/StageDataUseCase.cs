using Kai.Common.Data.Entity.Interface;
using Kai.Game.Domain.Repository.Interface;
using Kai.Game.Factory.Interface;

namespace Kai.Game.Domain.UseCase
{
    public sealed class StageDataUseCase
    {
        public StageDataUseCase(ILevelEntity levelEntity, IStageRepository stageRepository,
            IStageObjectFactory stageObjectFactory)
        {
            var level = levelEntity.GetLevel();
            var stageObjects = stageRepository.GetStageObjectDataList(level);

            foreach (var data in stageObjects)
            {
                var stageObject = stageRepository.GetStageObject(data.type, data.color);
                stageObjectFactory.GenerateStageObject(stageObject, data);
            }
        }
    }
}