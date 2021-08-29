using Kai.Common.Presentation.View;
using UniRx;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class TitleButton : MonoBehaviour
    {
        private void Start()
        {
            var buttonAnimator = GetComponent<ButtonAnimator>();
            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ => buttonAnimator.Play())
                .AddTo(this);
        }
    }
}