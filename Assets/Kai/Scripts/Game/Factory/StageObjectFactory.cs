using System;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Data.Entity;
using Kai.Game.Factory.Interface;
using Kai.Game.Presentation.View;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Kai.Game.Factory
{
    public sealed class StageObjectFactory : IStageObjectFactory
    {
        private IWriteOnlyPlayerContainer _playerContainer;
        private IWriteOnlyFlagContainer _flagContainer;
        private StageView _stageView;

        [Inject]
        private void Construct(IWriteOnlyPlayerContainer playerContainer, IWriteOnlyFlagContainer flagContainer,
            StageView stageView)
        {
            _playerContainer = playerContainer;
            _flagContainer = flagContainer;
            _stageView = stageView;
        }

        public void GenerateStageObject(StageObjectView stageObjectView, StageObject stageObject)
        {
            var instance = Object.Instantiate(stageObjectView, stageObject.position, GetQuaternion(stageObject.color));
            instance.transform.SetParent(_stageView.transform);

            switch (stageObject.type)
            {
                case StageObjectType.Player:
                    if (instance is PlayerView playerView)
                    {
                        _playerContainer.Add(playerView);
                    }
                    else
                    {
                        Debug.LogError($"container error: player");
                    }
                    break;
                case StageObjectType.Flag:
                    if (instance is FlagView flagView)
                    {
                        _flagContainer.Add(flagView);
                    }
                    else
                    {
                        Debug.LogError($"container error: flag");
                    }
                    break;
                case StageObjectType.Block:
                    break;
                case StageObjectType.None:
                default:
                    throw new ArgumentOutOfRangeException();
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