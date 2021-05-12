using Game.Application;
using Game.Presentation.View;
using UnityEngine;

namespace Game.Data.DataStore
{
    [CreateAssetMenu(fileName = "StageObjectData", menuName = "DataTable/StageObjectData", order = 0)]
    public sealed class StageObjectData : ScriptableObject
    {
        [SerializeField] private StageObjectView stageObjectPrefab = default;
        [SerializeField] private StageObjectType stageObjectType = default;
        [SerializeField] private ColorType colorType = default;

        public StageObjectView stageObject => stageObjectPrefab;
        public StageObjectType type => stageObjectType;
        public ColorType color => colorType;
    }
}