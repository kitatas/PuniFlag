using System.Collections.Generic;
using Kai.Common.Application;
using Kai.Title.Domain.UseCase.Interface;
using Kai.Title.Presentation.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace Kai.Title.Presentation.Controller
{
    public sealed class LanguageButtonController : MonoBehaviour
    {
        [SerializeField] private Sprite validImage = default;
        [SerializeField] private Sprite invalidImage = default;
        [SerializeField] private List<LanguageButtonView> languageButtonViews = default;

        [Inject]
        private void Construct(ISaveLanguageUseCase saveLanguageUseCase, IWriteOnlyLanguageUseCase languageUseCase)
        {
            ChangeButtonImage(saveLanguageUseCase.language);

            foreach (var languageButtonView in languageButtonViews)
            {
                languageButtonView
                    .OnClickLanguageAsObservable()
                    .Subscribe(language =>
                    {
                        ChangeButtonImage(language);
                        saveLanguageUseCase.SaveLanguage(language);
                        languageUseCase.SetLanguage(language);
                    })
                    .AddTo(languageButtonView);
            }
        }

        private void ChangeButtonImage(LanguageType languageType)
        {
            foreach (var languageButtonView in languageButtonViews)
            {
                if (languageButtonView.IsEqualLanguage(languageType))
                {
                    languageButtonView.ActivateButton(false);
                    languageButtonView.SetButtonImage(invalidImage);
                }
                else
                {
                    languageButtonView.ActivateButton(true);
                    languageButtonView.SetButtonImage(validImage);
                }
            }
        }
    }
}