using Common.Data.Entity.Interface;
using Game.Data.Entity;
using Game.Domain.Repository.Interface;
using Game.Factory.Interface;
using UnityEngine;

namespace Game.Domain.UseCase
{
    public sealed class StageDataUseCase
    {
        public StageDataUseCase(ILevelEntity levelEntity, IStageRepository stageRepository,
            IStageObjectFactory stageObjectFactory)
        {
            var level = levelEntity.GetLevel();
            var stageData = stageRepository.GetStageData(level).ToString();
            var stageDataEntity = JsonUtility.FromJson<StageDataEntity>(stageData);

            foreach (var data in stageDataEntity.stageObjects)
            {
                var stageObject = stageRepository.GetStageObject(data.type, data.color);
                stageObjectFactory.GenerateStageObject(stageObject, data);
            }
        }
    }
}