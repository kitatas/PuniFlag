using System;
using System.Threading;
using Common.Application;
using Common.Presentation.Controller;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.View
{
    public sealed class ClearView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clearText = default;

        private readonly float _animationTime = 0.3f;

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        public async UniTask ShowAsync(CancellationToken token)
        {
            _seController.PlaySe(SeType.StageClear);

            await clearText
                .DOText($"clear", _animationTime)
                .SetEase(Ease.Linear);

            await UniTask.Delay(TimeSpan.FromSeconds(_animationTime), cancellationToken: token);
        }
    }
}