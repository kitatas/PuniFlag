using System.Collections.Generic;
using Kai.Game.Application;
using Kai.Game.Data.Entity;
using Kai.Game.Presentation.View;

namespace Kai.Game.Domain.Repository.Interface
{
    public interface IStageRepository
    {
        StageObjectView GetStageObject(StageObjectType type, ColorType color);
        IEnumerable<StageObject> GetStageObjectDataList(int stageLevel);
    }
}