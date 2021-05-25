using System.Collections.Generic;
using Kai.Common.Application;
using Kai.Title.Domain.UseCase.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kai.Title.Presentation.View
{
    public sealed class LanguageButtonView : MonoBehaviour
    {
        [SerializeField] private Sprite validImage = default;
        [SerializeField] private Sprite invalidImage = default;

        [SerializeField] private Button japanese = default;
        [SerializeField] private Button english = default;
        private Dictionary<LanguageType, Button> _languageButtons;

        [Inject]
        private void Construct(ISaveLanguageUseCase saveLanguageUseCase, IWriteOnlyLanguageUseCase languageUseCase)
        {
            _languageButtons = new Dictionary<LanguageType, Button>()
            {
                {LanguageType.Japanese, japanese},
                {LanguageType.English, english},
            };

            ChangeSelectButton(saveLanguageUseCase.language);

            foreach (var languageButton in _languageButtons)
            {
                var language = languageButton.Key;
                var button = languageButton.Value;
                button
                    .OnClickAsObservable()
                    .Where(_ => saveLanguageUseCase.language != language)
                    .Subscribe(_ =>
                    {
                        ChangeSelectButton(language);
                        languageUseCase.SetLanguage(language);
                        saveLanguageUseCase.SaveLanguage(language);
                    })
                    .AddTo(button);
            }
        }

        private void ChangeSelectButton(LanguageType languageType)
        {
            foreach (var languageButton in _languageButtons)
            {
                var button = languageButton.Value;
                if (languageButton.Key == languageType)
                {
                    button.enabled = false;
                    button.image.sprite = invalidImage;
                }
                else
                {
                    button.enabled = true;
                    button.image.sprite = validImage;
                }
            }
        }
    }
}