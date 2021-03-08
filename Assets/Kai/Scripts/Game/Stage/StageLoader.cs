using Game.Stage.Level;
using UnityEngine;

namespace Game.Stage
{
    public sealed class StageLoader
    {
        public StageLoader(LevelModel levelModel, StageDataTable stageDataTable)
        {
            Object.Instantiate(stageDataTable.stageDataList[levelModel.GetLevel()]);
        }
    }
}