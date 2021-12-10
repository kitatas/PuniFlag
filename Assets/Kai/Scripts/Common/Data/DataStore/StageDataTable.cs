using System.Collections.Generic;
using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "StageDataTable", menuName = "DataTable/StageDataTable", order = 0)]
    public sealed class StageDataTable : ScriptableObject
    {
        [SerializeField] private List<StageData> stageData = default;

        public List<StageData> stageDataList => stageData;
    }
}