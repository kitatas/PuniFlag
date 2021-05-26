using System;
using Kai.Common.Application;
using Kai.Common.Presentation.View;
using UniRx;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class LanguageButtonView : MonoBehaviour
    {
        [SerializeField] private LanguageType languageType = default;

        private ButtonActivator _buttonActivator;

        private ButtonActivator buttonActivator
        {
            get
            {
                if (_buttonActivator == null)
                {
                    _buttonActivator = GetComponent<ButtonActivator>();
                }

                return _buttonActivator;
            }
        }

        public IObservable<LanguageType> OnClickLanguageAsObservable()
        {
            return buttonActivator.button
                .OnClickAsObservable()
                .Select(_ => languageType);
        }

        public bool IsEqualLanguage(LanguageType language)
        {
            return languageType == language;
        }

        public void SetButtonImage(Sprite sprite)
        {
            buttonActivator.button.image.sprite = sprite;
        }

        public void ActivateButton(bool value)
        {
            buttonActivator.Activate(value);
        }
    }
}