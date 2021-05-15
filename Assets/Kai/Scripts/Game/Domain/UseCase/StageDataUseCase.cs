using Game.Data.Entity;
using Game.Domain.Repository.Interface;
using Game.Factory.Interface;
using Game.Stage.Level;
using UnityEngine;

namespace Game.Domain.UseCase
{
    public sealed class StageDataUseCase
    {
        public StageDataUseCase(LevelModel levelModel, IStageRepository stageRepository,
            IStageObjectFactory stageObjectFactory)
        {
            var level = levelModel.GetLevel();
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