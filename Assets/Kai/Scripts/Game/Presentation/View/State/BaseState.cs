using System.Threading;
using Cysharp.Threading.Tasks;
using Kai.Game.Application;
using UnityEngine;

namespace Kai.Game.Presentation.View.State
{
    public abstract class BaseState : MonoBehaviour
    {
        public abstract GameState GetState();

        public virtual async UniTask InitAsync(CancellationToken token)
        {

        }

        public virtual async UniTask<GameState> TickAsync(CancellationToken token)
        {
            return GameState.None;
        }
    }
}