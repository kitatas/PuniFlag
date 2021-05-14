using System.Threading;
using Common.Application;
using Common.Presentation.Controller;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Common.Presentation.View
{
    public sealed class TransitionMaskView : MonoBehaviour
    {
        [SerializeField] private RectTransform up = default;
        [SerializeField] private RectTransform down = default;

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        public async UniTask FadeInAsync(CancellationToken token)
        {
            var delayTime = CommonViewConfig.FADE_TIME - 0.1f;
            _seController.DelayPlaySeAsync(SeType.Transition, delayTime, token).Forget();

            up.sizeDelta = new Vector2(320.0f, 181.0f);
            down.sizeDelta = new Vector2(320.0f, 181.0f);

            await DOTween.Sequence()
                .Append(up
                    .DOAnchorPosY(0.0f, CommonViewConfig.FADE_TIME))
                .Join(down
                    .DOAnchorPosY(0.0f, CommonViewConfig.FADE_TIME))
                .WithCancellation(token);
        }

        public async UniTask FadeOutAsync(CancellationToken token)
        {
            up.sizeDelta = new Vector2(320.0f, 180.0f);
            down.sizeDelta = new Vector2(320.0f, 180.0f);

            await DOTween.Sequence()
                .Append(up
                    .DOAnchorPosY(90.0f, CommonViewConfig.FADE_TIME))
                .Join(down
                    .DOAnchorPosY(-90.0f, CommonViewConfig.FADE_TIME))
                .WithCancellation(token);
        }

        public async UniTask FadeOutAllAsync(CancellationToken token)
        {
            up.sizeDelta = new Vector2(320.0f, 180.0f);
            down.sizeDelta = new Vector2(320.0f, 180.0f);

            await DOTween.Sequence()
                .Append(up
                    .DOAnchorPosY(110.0f, CommonViewConfig.FADE_TIME))
                .Join(down
                    .DOAnchorPosY(-110.0f, CommonViewConfig.FADE_TIME))
                .WithCancellation(token);
        }
    }
}