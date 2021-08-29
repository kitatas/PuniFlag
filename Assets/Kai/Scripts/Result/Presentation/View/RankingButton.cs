using Kai.Common.Presentation.View;
using UniRx;
using UnityEngine;

namespace Kai.Result.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class RankingButton : MonoBehaviour
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