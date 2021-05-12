using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.DataStore
{
    [CreateAssetMenu(fileName = "StageObjectTable", menuName = "DataTable/StageObjectTable", order = 0)]
    public sealed class StageObjectTable : ScriptableObject
    {
        [SerializeField] private List<StageObjectData> stageObjectData = default;

        public List<StageObjectData> stageObjectDataList => stageObjectData;
    }
}