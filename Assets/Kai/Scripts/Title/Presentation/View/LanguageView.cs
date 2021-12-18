using Kai.Common.Data.Entity;
using Kai.Title.Presentation.View.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Title.Presentation.View
{
    public sealed class LanguageView : MonoBehaviour
    {
        [SerializeField] private TitleScreenView titleScreenView = default;
        [SerializeField] private ConfigScreenView configScreenView = default;
        [SerializeField] private ExplainScreenView explainScreenView = default;
        [SerializeField] private InformationScreenView informationScreenView = default;
        [SerializeField] private Image titleLogo = default;
        [SerializeField] private Image titleLogoShadow = default;

        public void Show(LanguageScreenData languageScreenData)
        {
            titleScreenView.Show(languageScreenData.titleScreen);
            configScreenView.Show(languageScreenData.configScreen);
            explainScreenView.Show(languageScreenData.explainScreen);
            informationScreenView.Show(languageScreenData.informationScreen);
        }

        public void SetLogo(Sprite logo)
        {
            titleLogo.sprite = logo;
            titleLogoShadow.sprite = logo;
        }
    }
}