using Common.Application;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonAnimator : MonoBehaviour
    {
        private Vector3 _currentScale;
        private readonly float _rate = 0.85f;

        private Button _button;

        public Button button
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<Button>();
                }

                return _button;
            }
        }

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