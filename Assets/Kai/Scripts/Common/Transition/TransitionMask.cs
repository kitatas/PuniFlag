using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Common.Transition
{
    public sealed class TransitionMask : MonoBehaviour
    {
        [SerializeField] private RectTransform up = default;
        [SerializeField] private RectTransform down = default;

        public async UniTask FadeInAsync(CancellationToken token)
        {
            await DOTween.Sequence()
                .Append(up
                    .DOAnchorPosY(0.0f, Const.FADE_TIME))
                .Join(down
                    .DOAnchorPosY(0.0f, Const.FADE_TIME))
                .WithCancellation(token);
        }

        public async UniTask FadeOutAsync(CancellationToken token)
        {
            await DOTween.Sequence()
                .Append(up
                    .DOAnchorPosY(100.0f, Const.FADE_TIME))
                .Join(down
                    .DOAnchorPosY(-100.0f, Const.FADE_TIME))
                .WithCancellation(token);
        }
    }
}