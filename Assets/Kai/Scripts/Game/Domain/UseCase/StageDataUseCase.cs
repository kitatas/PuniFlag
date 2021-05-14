using System;
using Game.Application;
using Game.Data.Container.Interface;
using Game.Data.Entity;
using Game.Domain.Repository.Interface;
using Game.Factory.Interface;
using Game.Presentation.View;
using Game.Stage.Level;
using UnityEngine;

namespace Game.Domain.UseCase
{
    public sealed class StageDataUseCase
    {
        public StageDataUseCase(LevelModel levelModel, IStageRepository stageRepository,
            IStageObjectFactory stageObjectFactory, IPlayerContainer playerContainer, IFlagContainer flagContainer)
        {
            var level = levelModel.GetLevel();
            var stageData = stageRepository.GetStageData(level).ToString();
            var stageDataEntity = JsonUtility.FromJson<StageDataEntity>(stageData);

            foreach (var data in stageDataEntity.stageObjects)
            {
                var stageObject = stageRepository.GetStageObject(data.type, data.color);
                var instance = stageObjectFactory.GenerateStageObject(stageObject.gameObject, data.position, GetQuaternion(data.color));

                switch (data.type)
                {
                    case StageObjectType.Player:
                        playerContainer.Add(instance.GetComponent<PlayerView>());
                        break;
                    case StageObjectType.Flag:
                        flagContainer.Add(instance.GetComponent<FlagView>());
                        break;
                    case StageObjectType.Block:
                        break;
                    case StageObjectType.None:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static Quaternion GetQuaternion(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.None:
                    return StageObjectConfig.rotateDefault;
                case ColorType.Red:
                    return StageObjectConfig.rotateRed;
                case ColorType.Green:
                    return StageObjectConfig.rotateGreen;
                case ColorType.Blue:
                    return StageObjectConfig.rotateBlue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null);
            }
        }
    }
}