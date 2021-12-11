using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class InformationScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI credit = default;
        [SerializeField] private TextMeshProUGUI license = default;
        [SerializeField] private TextMeshProUGUI privacy = default;

        public void Show(InformationScreen informationScreen)
        {
            credit.SetTextData(informationScreen.credit);
            license.SetTextData(informationScreen.license);
            privacy.SetTextData(informationScreen.privacyPolicy);
        }
    }
}