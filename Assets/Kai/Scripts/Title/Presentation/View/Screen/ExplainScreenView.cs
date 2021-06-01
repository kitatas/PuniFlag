using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class ExplainScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title = default;
        [SerializeField] private TextMeshProUGUI gravityTitle = default;
        [SerializeField] private TextMeshProUGUI gravityDetail = default;
        [SerializeField] private TextMeshProUGUI rotateTitle = default;
        [SerializeField] private TextMeshProUGUI rotateDetail = default;
        [SerializeField] private TextMeshProUGUI moveTitle = default;
        [SerializeField] private TextMeshProUGUI moveDetail = default;
        [SerializeField] private TextMeshProUGUI resetTitle = default;
        [SerializeField] private TextMeshProUGUI resetDetail = default;
        [SerializeField] private TextMeshProUGUI stepTitle = default;
        [SerializeField] private TextMeshProUGUI stepDetail = default;
        [SerializeField] private TextMeshProUGUI flagTitle = default;
        [SerializeField] private TextMeshProUGUI flagDetail = default;

        public void Show(ExplainScreen explainScreen)
        {
            title.SetTextData(explainScreen.title);
            gravityTitle.SetTextData(explainScreen.gravity.title);
            gravityDetail.SetTextData(explainScreen.gravity.detail);
            rotateTitle.SetTextData(explainScreen.rotate.title);
            rotateDetail.SetTextData(explainScreen.rotate.detail);
            moveTitle.SetTextData(explainScreen.move.title);
            moveDetail.SetTextData(explainScreen.move.detail);
            resetTitle.SetTextData(explainScreen.reset.title);
            resetDetail.SetTextData(explainScreen.reset.detail);
            stepTitle.SetTextData(explainScreen.step.title);
            stepDetail.SetTextData(explainScreen.step.detail);
            flagTitle.SetTextData(explainScreen.flag.title);
            flagDetail.SetTextData(explainScreen.flag.detail);
        }
    }
}