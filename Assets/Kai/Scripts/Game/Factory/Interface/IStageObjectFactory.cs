using Kai.Game.Data.Entity;
using Kai.Game.Presentation.View;

namespace Kai.Game.Factory.Interface
{
    public interface IStageObjectFactory
    {
        void GenerateStageObject(StageObjectView stageObjectView, StageObject stageObject);
    }
}