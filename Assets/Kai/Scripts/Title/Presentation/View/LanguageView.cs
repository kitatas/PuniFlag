using System.Collections.Generic;
using Kai.Common.Data.DataStore;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    public sealed class LanguageView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleName = default;
        [SerializeField] private List<ExplainView> explainViews = default;

        public void Show(LanguageData languageData)
        {
            titleName.text = $"{languageData.title}";

            foreach (var explainData in languageData.explain)
            {
                var view = explainViews
                    .Find(x => x.explain == explainData.explain);
                view.SetText(explainData.title, explainData.detail);
            }
        }
    }
}