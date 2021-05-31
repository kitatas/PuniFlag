using Kai.Common.Data.Entity;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    public sealed class LanguageView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleName = default;
        [SerializeField] private TextMeshProUGUI infoCredit = default;
        [SerializeField] private TextMeshProUGUI infoLicense = default;
        [SerializeField] private TextMeshProUGUI infoExternalSite = default;
        [SerializeField] private TextMeshProUGUI subTitleLanguage = default;
        [SerializeField] private TextMeshProUGUI subTitleVolume = default;
        [SerializeField] private TextMeshProUGUI subTitleDeveloper = default;
        [SerializeField] private TextMeshProUGUI subTitleSound = default;
        [SerializeField] private TextMeshProUGUI subTitleFont = default;
        [SerializeField] private TextMeshProUGUI subTitlePrivacy = default;
        [SerializeField] private TextMeshProUGUI explainGravityTitle = default;
        [SerializeField] private TextMeshProUGUI explainGravityDetail = default;
        [SerializeField] private TextMeshProUGUI explainRotateTitle = default;
        [SerializeField] private TextMeshProUGUI explainRotateDetail = default;
        [SerializeField] private TextMeshProUGUI explainMoveTitle = default;
        [SerializeField] private TextMeshProUGUI explainMoveDetail = default;
        [SerializeField] private TextMeshProUGUI explainResetTitle = default;
        [SerializeField] private TextMeshProUGUI explainResetDetail = default;
        [SerializeField] private TextMeshProUGUI explainStepTitle = default;
        [SerializeField] private TextMeshProUGUI explainStepDetail = default;
        [SerializeField] private TextMeshProUGUI explainFlagTitle = default;
        [SerializeField] private TextMeshProUGUI explainFlagDetail = default;

        private const string INFO_TITLE = "+++";

        private const string SUB_TITLE_HEADER =
            "================================================================================================";

        private const string SUB_TITLE_FOOTER =
            "------------------------------------------------------------------------------------------------";

        public void Show(LanguageData languageData)
        {
            titleName.text = $"{languageData.titleName}";

            ShowInfoTitle(languageData.infoTitle);
            ShowSubTitle(languageData.subTitle);
            ShowExplain(languageData.explain);
        }

        private void ShowInfoTitle(InfoTitle infoTitle)
        {
            infoCredit.text = $"{INFO_TITLE} {infoTitle.credit} {INFO_TITLE}";
            infoLicense.text = $"{INFO_TITLE} {infoTitle.license} {INFO_TITLE}";
            infoExternalSite.text = $"{INFO_TITLE} {infoTitle.externalSite} {INFO_TITLE}";
        }

        private void ShowSubTitle(SubTitle subTitle)
        {
            subTitleLanguage.text = $"{SUB_TITLE_HEADER}\n{subTitle.language}\n{SUB_TITLE_FOOTER}";
            subTitleVolume.text = $"{SUB_TITLE_HEADER}\n{subTitle.volume}\n{SUB_TITLE_FOOTER}";
            subTitleDeveloper.text = $"{SUB_TITLE_HEADER}\n{subTitle.developer}\n{SUB_TITLE_FOOTER}";
            subTitleSound.text = $"{SUB_TITLE_HEADER}\n{subTitle.sound}\n{SUB_TITLE_FOOTER}";
            subTitleFont.text = $"{SUB_TITLE_HEADER}\n{subTitle.font}\n{SUB_TITLE_FOOTER}";
            subTitlePrivacy.text = $"{SUB_TITLE_HEADER}\n{subTitle.privacyPolicy}\n{SUB_TITLE_FOOTER}";
        }

        private void ShowExplain(Explain explain)
        {
            explainGravityTitle.text = $"{explain.gravity.title}";
            explainGravityDetail.text = $"{explain.gravity.detail}";
            explainRotateTitle.text = $"{explain.rotate.title}";
            explainRotateDetail.text = $"{explain.rotate.detail}";
            explainMoveTitle.text = $"{explain.move.title}";
            explainMoveDetail.text = $"{explain.move.detail}";
            explainResetTitle.text = $"{explain.reset.title}";
            explainResetDetail.text = $"{explain.reset.detail}";
            explainStepTitle.text = $"{explain.step.title}";
            explainStepDetail.text = $"{explain.step.detail}";
            explainFlagTitle.text = $"{explain.flag.title}";
            explainFlagDetail.text = $"{explain.flag.detail}";
        }
    }
}