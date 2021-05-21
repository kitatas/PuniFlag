using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using UnityEngine;
using Zenject;

namespace Kai.Game.Presentation.View
{
    public sealed class FreePlayNextView : MonoBehaviour
    {
        [SerializeField] private RectTransform leftSide = default;
        [SerializeField] private RectTransform rightSide = default;
        [SerializeField] private NextButtonView reload = default;
        [SerializeField] private NextButtonView loadNext = default;
        [SerializeField] private NextButtonView loadTitle = default;
        private List<NextButtonView> _nextButtonViews;

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        public void Init()
        {
            _nextButtonViews = new List<NextButtonView>
            {
                reload,
                loadNext,
                loadTitle,
            };

            foreach (var nextButtonView in _nextButtonViews)
            {
                nextButtonView.Init();
                nextButtonView.FadeIn();
            }
        }

        public async UniTaskVoid ShowAsync(CancellationToken token)
        {
            var delayTime = CommonViewConfig.FADE_TIME - 0.1f;
            _seController.DelayPlaySeAsync(SeType.Transition, delayTime, token).Forget();

            await (
                leftSide
                    .DOAnchorPosX(80.0f, CommonViewConfig.FADE_TIME)
                    .SetEase(Ease.InQuart)
                    .WithCancellation(token),
                rightSide
                    .DOAnchorPosX(-80.0f, CommonViewConfig.FADE_TIME)
                    .SetEase(Ease.InQuart)
                    .WithCancellation(token)
            );

            await UniTask.Delay(TimeSpan.FromSeconds(CommonViewConfig.FADE_TIME), cancellationToken: token);

            foreach (var nextButtonView in _nextButtonViews)
            {
                nextButtonView.FadeOut();
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            }

            ActivateAllButton(true);
        }

        private void ActivateAllButton(bool value)
        {
            foreach (var nextButtonView in _nextButtonViews)
            {
                nextButtonView.Activate(value);
            }
        }
    }
}