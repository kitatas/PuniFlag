using Game.Stage.Level;
using UnityEngine;

namespace Game.Stage
{
    public sealed class StageLoader
    {
        public StageLoader(LevelModel levelModel, StageData stageData)
        {
            Object.Instantiate(stageData.stageDataList[levelModel.GetLevel()]);
        }
    }
}