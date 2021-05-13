using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Application;
using Game.Domain.UseCase.Interface;
using Game.Presentation.View.State;
using UniRx;

namespace Game.Presentation.Presenter
{
    public sealed class StatePresenter
    {
        private readonly CompositeDisposable _disposable;
        private readonly CancellationTokenSource _tokenSource;

        private readonly List<BaseState> _states;
        private readonly IGameStateUseCase _gameStateUseCase;

        public StatePresenter(IGameStateUseCase gameStateUseCase, InputState inputState, MoveState moveState,
            ClearState clearState)
        {
            _disposable = new CompositeDisposable();
            _tokenSource = new CancellationTokenSource();
            _states = new List<BaseState>
            {
                inputState,
                moveState,
                clearState,
            };
            _gameStateUseCase = gameStateUseCase;

            Init();

            _gameStateUseCase.gameState
                .Subscribe(state =>
                {
                    // 
                    TickAsync(state, _tokenSource.Token).Forget();
                })
                .AddTo(_disposable);
        }

        ~StatePresenter()
        {
            _disposable?.Dispose();
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        private void Init()
        {
            foreach (var state in _states)
            {
                state.InitAsync(_tokenSource.Token).Forget();
            }
        }

        private async UniTask TickAsync(GameState state, CancellationToken token)
        {
            if (state == GameState.None)
            {
                return;
            }

            var currentState = _states.Find(x => x.GetState() == state);
            var nextState = await currentState.TickAsync(token);
            _gameStateUseCase.SetState(nextState);
        }
    }
}