using System;
using Kai.Game.Application;
using Kai.Game.Data.Container.Interface;
using Kai.Game.Data.Entity;
using Kai.Game.Factory.Interface;
using Kai.Game.Presentation.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kai.Game.Factory
{
    public sealed class StageObjectFactory : IStageObjectFactory
    {
        private readonly IWriteOnlyPlayerContainer _playerContainer;
        private readonly IWriteOnlyFlagContainer _flagContainer;
        private readonly IWriteOnlyColorBlockContainer _colorBlockContainer;
        private readonly StageView _stageView;

        public StageObjectFactory(IWriteOnlyPlayerContainer playerContainer, IWriteOnlyFlagContainer flagContainer,
            IWriteOnlyColorBlockContainer colorBlockContainer, StageView stageView)
        {
            _playerContainer = playerContainer;
            _flagContainer = flagContainer;
            _colorBlockContainer = colorBlockContainer;
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
                    if (instance is ColorBlockView colorBlockView)
                    {
                        _colorBlockContainer.Add(colorBlockView);
                    }
                    break;
                case StageObjectType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Quaternion GetQuaternion(ColorType colorType)
        {
            return colorType switch
            {
                ColorType.None   => StageObjectConfig.rotateDefault,
                ColorType.Red    => StageObjectConfig.rotateRed,
                ColorType.Green  => StageObjectConfig.rotateGreen,
                ColorType.Blue   => StageObjectConfig.rotateBlue,
                ColorType.Purple => StageObjectConfig.rotatePurple,
                _ => throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null)
            };
        }
    }
}