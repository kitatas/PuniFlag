using DG.Tweening;
using Kai.Common.Application;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    public sealed class ButtonAnimator : MonoBehaviour
    {
        private Vector3 _currentScale;
        private readonly float _rate = 0.85f;

        private ButtonActivator _buttonActivator;
        private Button _button;
        public Button button => _button ??= (_buttonActivator ??= GetComponent<ButtonActivator>()).button;

        private void Awake()
        {
            _currentScale = transform.localScale;
        }

        public void Play()
        {
            DOTween.Sequence()
                .Append(button.image.rectTransform
                    .DOScale(_currentScale * _rate, CommonViewConfig.UI_ANIMATION_TIME))
                .Append(button.image.rectTransform
                    .DOScale(_currentScale, CommonViewConfig.UI_ANIMATION_TIME));
        }
    }
}