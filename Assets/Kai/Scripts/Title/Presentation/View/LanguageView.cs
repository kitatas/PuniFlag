using Kai.Common.Data.Entity;
using Kai.Title.Presentation.View.Screen;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    public sealed class LanguageView : MonoBehaviour
    {
        [SerializeField] private TitleScreenView titleScreenView = default;
        [SerializeField] private ConfigScreenView configScreenView = default;
        [SerializeField] private ExplainScreenView explainScreenView = default;
        [SerializeField] private InformationScreenView informationScreenView = default;

        public void Show(LanguageData languageData)
        {
            titleScreenView.Show(languageData.titleScreen);
            configScreenView.Show(languageData.configScreen);
            explainScreenView.Show(languageData.explainScreen);
            informationScreenView.Show(languageData.informationScreen);
        }
    }
}