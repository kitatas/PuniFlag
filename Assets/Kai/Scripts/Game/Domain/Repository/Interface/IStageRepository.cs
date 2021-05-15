using Kai.Game.Application;
using Kai.Game.Presentation.View;
using UnityEngine;

namespace Kai.Game.Domain.Repository.Interface
{
    public interface IStageRepository
    {
        StageObjectView GetStageObject(StageObjectType type, ColorType color);
        TextAsset GetStageData(int stageLevel);
    }
}