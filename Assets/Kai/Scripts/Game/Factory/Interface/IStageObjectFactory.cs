using Game.Data.Entity;
using Game.Presentation.View;

namespace Game.Factory.Interface
{
    public interface IStageObjectFactory
    {
        void GenerateStageObject(StageObjectView stageObjectView, StageObject stageObject);
    }
}