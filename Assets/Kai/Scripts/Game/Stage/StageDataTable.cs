using System.Collections.Generic;
using UnityEngine;

namespace Game.Stage
{
    [CreateAssetMenu(fileName = "StageDataTable", menuName = "DataTable/StageDataTable", order = 0)]
    public sealed class StageDataTable : ScriptableObject
    {
        [SerializeField] private List<GameObject> stageData = default;

        public List<GameObject> stageDataList => stageData;
    }
}