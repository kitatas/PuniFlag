using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class PolicyScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title = default;
        [SerializeField] private TextMeshProUGUI body = default;
        [SerializeField] private TextMeshProUGUI yes = default;
        [SerializeField] private TextMeshProUGUI no = default;

        public void Show(PolicyScreen policyScreen)
        {
            title.SetTextData(policyScreen.title);
            body.SetTextData(policyScreen.body);
            yes.SetTextData(policyScreen.yes);
            no.SetTextData(policyScreen.no);
        }
    }
}