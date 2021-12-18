using System.Collections.Generic;
using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "LanguageTable", menuName = "DataTable/LanguageTable", order = 0)]
    public sealed class LanguageTable : ScriptableObject
    {
        [SerializeField] private List<LanguageData> languageDataList = default;
        
        public List<LanguageData> languageData => languageDataList;
    }
}