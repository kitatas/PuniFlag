using UnityEngine;

namespace Game.Stage
{
    public sealed class StageLoader
    {
        public StageLoader(int level, StageData stageData)
        {
            Object.Instantiate(stageData.stageDataList[level]);
        }
    }
}