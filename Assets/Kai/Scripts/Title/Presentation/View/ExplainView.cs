using Kai.Common.Application;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    public sealed class ExplainView : MonoBehaviour
    {
        [SerializeField] private ExplainType explainType = default;
        [SerializeField] private TextMeshProUGUI titleText = default;
        [SerializeField] private TextMeshProUGUI detailText = default;

        public ExplainType explain => explainType;

        public void SetText(string title, string detail)
        {
            titleText.text = $"{title}";
            detailText.text = $"{detail}";
        }
    }
}