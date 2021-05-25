using System;
using System.Collections.Generic;
using Kai.Common.Application;
using UnityEngine;

namespace Kai.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = "LanguageData", menuName = "DataTable/LanguageData", order = 0)]
    public sealed class LanguageData : ScriptableObject
    {
        [SerializeField] private LanguageType languageType = default;
        [SerializeField] private string titleName = default;
        [SerializeField] private List<ExplainData> explainData = default;

        public LanguageType language => languageType;
        public string title => titleName;
        public List<ExplainData> explain => explainData;
    }

    [Serializable]
    public sealed class ExplainData
    {
        [SerializeField] private ExplainType explainType = default;
        [SerializeField] private string titleText = default;
        [SerializeField] private string detailText = default;

        public ExplainType explain => explainType;
        public string title => titleText;
        public string detail => detailText;
    }
}