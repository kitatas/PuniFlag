using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Application;
using UnityEngine;

namespace Game.Presentation.View.State
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