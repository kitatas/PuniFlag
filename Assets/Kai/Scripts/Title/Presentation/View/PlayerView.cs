using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Presentation.View;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(PlayerSpriteView))]
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerSpriteView playerSpriteView = default;

        private void Start()
        {
            TickAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTaskVoid TickAsync(CancellationToken token)
        {
            while (true)
            {
                playerSpriteView.SetNormal();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

                playerSpriteView.SetMovement();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);
            }
        }
    }
}