using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class InformationScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title = default;
        [SerializeField] private TextMeshProUGUI credit = default;
        [SerializeField] private TextMeshProUGUI license = default;
        [SerializeField] private TextMeshProUGUI externalSite = default;
        [SerializeField] private TextMeshProUGUI developer = default;
        [SerializeField] private TextMeshProUGUI sound = default;
        [SerializeField] private TextMeshProUGUI font = default;
        [SerializeField] private TextMeshProUGUI privacy = default;

        public void Show(InformationScreen informationScreen)
        {
            title.SetTextData(informationScreen.title);
            credit.SetTextData(informationScreen.credit);
            license.SetTextData(informationScreen.license);
            externalSite.SetTextData(informationScreen.externalSite);
            developer.SetTextData(informationScreen.developer);
            sound.SetTextData(informationScreen.sound);
            font.SetTextData(informationScreen.font);
            privacy.SetTextData(informationScreen.privacyPolicy);
        }
    }
}