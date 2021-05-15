using Kai.Common.Data.Entity.Interface;
using Kai.Game.Data.Entity;
using Kai.Game.Domain.Repository.Interface;
using Kai.Game.Factory.Interface;
using UnityEngine;

namespace Kai.Game.Domain.UseCase
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