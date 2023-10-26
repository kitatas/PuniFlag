using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(StageData), menuName = "DataTable/" + nameof(StageData), order = 0)]
    public sealed class StageData : ScriptableObject
    {
        [SerializeField] private Sprite lockTexture = default;
        [SerializeField] private Sprite clearTexture = default;
        [SerializeField] private TextAsset stageJsonData = default;

        public Sprite GetButtonTexture(bool isClear) => isClear ? clearTexture : lockTexture;

        public TextAsset stageData => stageJsonData;
    }
}