using Game.Application;
using Game.Presentation.View;
using UnityEngine;

namespace Game.Domain.Repository.Interface
{
    public interface IStageRepository
    {
        StageObjectView GetStageObject(StageObjectType type, ColorType color);
        TextAsset GetStageData(int stageLevel);
    }
}