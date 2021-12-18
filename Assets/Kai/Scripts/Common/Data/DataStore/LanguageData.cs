using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(LanguageData), menuName = "DataTable/" + nameof(LanguageData), order = 0)]
    public sealed class LanguageData : ScriptableObject
    {
        [SerializeField] private LanguageType type = default;
        [SerializeField] private TextAsset json = default;
        [SerializeField] private Sprite logo = default;

        public LanguageType languageType => type;
        public TextAsset jsonData => json;
        public Sprite titleLogo => logo;
    }
}