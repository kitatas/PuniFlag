using System.Collections.Generic;
using UnityEngine;

namespace Game.Stage
{
    [CreateAssetMenu(fileName = "StageData", menuName = "DataTable/StageData", order = 0)]
    public sealed class StageData : ScriptableObject
    {
        [SerializeField] private List<GameObject> stageData = default;

        public List<GameObject> stageDataList => stageData;
    }
}