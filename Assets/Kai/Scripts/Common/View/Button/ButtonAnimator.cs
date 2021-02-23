using DG.Tweening;
using UnityEngine;

namespace Common.View.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class ButtonAnimator : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;
        private readonly float _rate = 0.85f;

        private void Awake()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
        }

        public void Play()
        {
            DOTween.Sequence()
                .Append(_button.image.rectTransform
                    .DOScale(Vector3.one * _rate, Const.UI_ANIMATION_TIME))
                .Append(_button.image.rectTransform
                    .DOScale(Vector3.one, Const.UI_ANIMATION_TIME));
        }
    }
}