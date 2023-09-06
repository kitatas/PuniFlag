using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Presentation.View.State
{
    public abstract class BaseState : MonoBehaviour
    {
        public abstract GameState GetState();

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async UniTask InitAsync(CancellationToken token)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async UniTask<GameState> TickAsync(CancellationToken token)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return GameState.None;
        }
    }
}