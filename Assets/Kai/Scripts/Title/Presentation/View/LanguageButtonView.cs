using System.Collections.Generic;
using Kai.Common.Application;
using Kai.Common.Domain.UseCase.Interface;
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
        private void Construct(ISaveDataUseCase saveDataUseCase)
        {
            _languageButtons = new Dictionary<LanguageType, Button>()
            {
                {LanguageType.Japanese, japanese},
                {LanguageType.English, english},
            };

            ChangeSelectButton(saveDataUseCase.saveData.language);

            foreach (var languageButton in _languageButtons)
            {
                var language = languageButton.Key;
                var button = languageButton.Value;
                button
                    .OnClickAsObservable()
                    .Where(_ => saveDataUseCase.saveData.language != language)
                    .Subscribe(_ =>
                    {
                        ChangeSelectButton(language);
                        saveDataUseCase.saveData.language = language;
                        saveDataUseCase.Save();
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